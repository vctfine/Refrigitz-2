# Sugar, a UCI chess playing engine derived from Stockfish
# Copyright (C) 2008-2014 Marco Costalba, Joona Kiiski, Tord Romstad
# Sugar is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# Sugar is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <http://www.gnu.org/licenses/>.


### ==========================================================================
### Section 1. General Configuration
### ==========================================================================

### Establish the operating system name
UNAME = $(shell uname)

### Executable name
EXE = sugar

### Installation dir definitions
PREFIX = /usr/local
# Haiku has a non-standard filesystem layout
ifeq ($(UNAME),Haiku)
	PREFIX=/boot/system/non-packaged
endif
BINDIR = $(PREFIX)/bin

### Built-in bench for pgo-builds
PGOBENCH = ./$(EXE) bench 32 1 2 default time
### Object files
OBJS = bench.o bitbase.o bitboard.o book.o endgame.o evaluate.o main.o \
	material.o misc.o movegen.o movepick.o notation.o pawns.o \
	position.o searching.o tb_syzygy.o thread.o timeman.o tt.o uci.o ucioption.o MALLOC.o

### ==========================================================================
### Section 2. High-level Configuration
### ==========================================================================
#
# flag                --- Comp switch --- Description
# ----------------------------------------------------------------------------
#
# debug = yes/no      --- -DNDEBUG         --- Enable/Disable debug mode
# optimize = yes/no   --- (-O3/-fast etc.) --- Enable/Disable optimizations
# arch = (name)       --- (-arch)          --- Target architecture
# os = (name)         ---                  --- Target operating system
# bits = 64/32        --- -DIS_64BIT       --- 64-/32-bit operating system
# prefetch = yes/no   --- -DUSE_PREFETCH   --- Use prefetch x86 asm-instruction
# bsfq = yes/no       --- -DUSE_BSFQ       --- Use bsfq x86_64 asm-instruction (only
#                                              with GCC and ICC 64-bit)
# popcnt = yes/no     --- -DUSE_POPCNT     --- Use popcnt x86_64 asm-instruction
# sse = yes/no        --- -msse            --- Use Intel Streaming SIMD Extensions
# pext = yes/no       --- -DUSE_PEXT       --- Use pext x86_64 asm-instruction
#
# Note that Makefile is space sensitive, so when adding new architectures
# or modifying existing flags, you have to make sure there are no extra spaces
# at the end of the line for flag values.

### 2.1. General and architecture defaults
optimize = yes
debug = no
os = any
bits = 32
prefetch = no
bsfq = no
popcnt = no
sse = no
pext = no

### 2.2 Architecture specific

ifeq ($(ARCH),general-32)
	arch = any
endif

ifeq ($(ARCH),x86-32-old)
	arch = i386
endif

ifeq ($(ARCH),x86-32)
	arch = i386
	prefetch = yes
	sse = yes
endif

ifeq ($(ARCH),general-64)
	arch = any
	bits = 64
endif

ifeq ($(ARCH),x86-64)
	arch = x86_64
	bits = 64
	prefetch = yes
	bsfq = yes
	sse = yes
endif

ifeq ($(ARCH),x86-64-modern)
	arch = x86_64
	bits = 64
	prefetch = yes
	bsfq = yes
	popcnt = yes
	sse = yes
endif

ifeq ($(ARCH),x86-64-bmi2)
	arch = x86_64
	bits = 64
	prefetch = yes
	bsfq = yes
	popcnt = yes
	sse = yes
	pext = yes
endif

ifeq ($(ARCH),armv7)
	arch = armv7
	prefetch = yes
	bsfq = yes
endif

ifeq ($(ARCH),ppc-32)
	arch = ppc
endif

ifeq ($(ARCH),ppc-64)
	arch = ppc64
	bits = 64
endif


### ==========================================================================
### Section 3. Low-level configuration
### ==========================================================================

### 3.1 Selecting compiler (default = gcc)

CXXFLAGS += -Wall -Wcast-qual -fno-exceptions -fno-rtti $(EXTRACXXFLAGS)
LDFLAGS += $(EXTRALDFLAGS)

ifeq ($(COMP),)
	COMP=gcc
endif

ifeq ($(COMP),gcc)
	comp=gcc
	CXX=g++
	CXXFLAGS += -ansi -pedantic -Wno-long-long -Wextra -Wshadow
endif

ifeq ($(COMP),mingw)
	comp=mingw
	CXX=g++
	CXXFLAGS += -Wextra -Wshadow
	LDFLAGS += -static-libstdc++ -static-libgcc -static -lpthread 
endif

ifeq ($(COMP),icc)
	comp=icc
	CXX=icpc
	CXXFLAGS += -diag-disable 1476,10120 -Wcheck -Wabi -Wdeprecated -strict-ansi
endif

ifeq ($(COMP),clang)
	comp=clang
	CXX=clang++
	CXXFLAGS += -pedantic -Wno-long-long -Wextra -Wshadow
endif

ifeq ($(comp),icc)
	profile_prepare = icc-profile-prepare
	profile_make = icc-profile-make
	profile_use = icc-profile-use
	profile_clean = icc-profile-clean
else
	profile_prepare = gcc-profile-prepare
	profile_make = gcc-profile-make
	profile_use = gcc-profile-use
	profile_clean = gcc-profile-clean
endif

ifeq ($(UNAME),Darwin)
	CXXFLAGS += -arch $(arch) -mmacosx-version-min=10.6
	LDFLAGS += -arch $(arch) -mmacosx-version-min=10.6
endif

### On mingw use Windows threads, otherwise POSIX
ifneq ($(comp),mingw)
	# On Android Bionic's C library comes with its own pthread implementation bundled in
	ifneq ($(arch),armv7)
		# Haiku has pthreads in its libroot, so only link it in on other platforms
		ifneq ($(UNAME),Haiku)
			LDFLAGS += -lpthread
		endif
	endif
endif

### 3.4 Debugging
ifeq ($(debug),no)
	CXXFLAGS += -DNDEBUG
else
	CXXFLAGS += -g
endif

### 3.5 Optimization
ifeq ($(optimize),yes)

	ifeq ($(comp),gcc)
		CXXFLAGS += -O3

		ifeq ($(UNAME),Darwin)
			ifeq ($(arch),i386)
				CXXFLAGS += -mdynamic-no-pic
			endif
			ifeq ($(arch),x86_64)
				CXXFLAGS += -mdynamic-no-pic
			endif
		endif

		ifeq ($(arch),armv7)
			CXXFLAGS += -fno-gcse -mthumb -march=armv7-a -mfloat-abi=softfp
		endif
	endif

	ifeq ($(comp),mingw)
		CXXFLAGS += -O3
	endif

	ifeq ($(comp),icc)
		ifeq ($(UNAME),Darwin)
			CXXFLAGS += -fast -mdynamic-no-pic
		else
			CXXFLAGS += -fast
		endif
	endif

	ifeq ($(comp),clang)
		CXXFLAGS += -O3

		ifeq ($(UNAME),Darwin)
			ifeq ($(pext),no)
				CXXFLAGS += -flto
				LDFLAGS += $(CXXFLAGS)
			endif
			ifeq ($(arch),i386)
				CXXFLAGS += -mdynamic-no-pic
			endif
			ifeq ($(arch),x86_64)
				CXXFLAGS += -mdynamic-no-pic
			endif
		endif
	endif
endif

### 3.6. Bits
ifeq ($(bits),64)
	CXXFLAGS += -DIS_64BIT
endif

### 3.7 prefetch
ifeq ($(prefetch),yes)
	ifeq ($(sse),yes)
		CXXFLAGS += -msse
		DEPENDFLAGS += -msse
	endif
else
	CXXFLAGS += -DNO_PREFETCH
endif

### 3.8 bsfq
ifeq ($(bsfq),yes)
	CXXFLAGS += -DUSE_BSFQ
endif

### 3.9 popcnt
ifeq ($(popcnt),yes)
		CXXFLAGS += -msse3 -DUSE_POPCNT -mavx -DUSE_AVX
endif

### 3.10 pext
ifeq ($(pext),yes)
	CXXFLAGS += -DUSE_PEXT
	ifeq ($(comp),$(filter $(comp),gcc clang mingw))
		CXXFLAGS += -mbmi -mbmi2
	endif
endif

### 3.11 Link Time Optimization, it works since gcc 4.5 but not on mingw.
### This is a mix of compile and link time options because the lto link phase
### needs access to the optimization flags.
ifeq ($(comp),gcc)
	ifeq ($(optimize),yes)
	ifeq ($(debug),no)
		GCC_MAJOR := `$(CXX) -dumpversion | cut -f1 -d.`
		GCC_MINOR := `$(CXX) -dumpversion | cut -f2 -d.`
		ifeq (1,$(shell expr \( $(GCC_MAJOR) \> 4 \) \| \( $(GCC_MAJOR) \= 4 \& $(GCC_MINOR) \>= 5 \)))
			CXXFLAGS += -flto
			LDFLAGS += $(CXXFLAGS)
		endif
	endif
	endif
endif

### ==========================================================================
### Section 4. Public targets
### ==========================================================================

help:
	@echo ""
	@echo "To compile sugar, type: "
	@echo ""
	@echo "make target ARCH=arch [COMP=comp]"
	@echo ""
	@echo "Supported targets:"
	@echo ""
	@echo "build                   > Standard build"
	@echo "profile-build           > PGO build"
	@echo "strip                   > Strip executable"
	@echo "install                 > Install executable"
	@echo "clean                   > Clean up"
	@echo ""
	@echo "Supported archs:"
	@echo ""
	@echo "x86-64                  > x86 64-bit"
	@echo "x86-64-modern           > x86 64-bit with popcnt support"
	@echo "x86-64-bmi2             > x86 64-bit with pext support"
	@echo "x86-32                  > x86 32-bit with SSE support"
	@echo "x86-32-old              > x86 32-bit fall back for old hardware"
	@echo "ppc-64                  > PPC 64-bit"
	@echo "ppc-32                  > PPC 32-bit"
	@echo "armv7                   > ARMv7 32-bit"
	@echo "general-64              > unspecified 64-bit"
	@echo "general-32              > unspecified 32-bit"
	@echo ""
	@echo "Supported compilers:"
	@echo ""
	@echo "gcc                     > Gnu compiler (default)"
	@echo "mingw                   > Gnu compiler with MinGW under Windows"
	@echo "clang                   > LLVM Clang compiler"
	@echo "icc                     > Intel compiler"
	@echo ""
	@echo "Non-standard targets:"
	@echo ""
	@echo "make hpux               >  Compile for HP-UX. Compiler = aCC"
	@echo ""
	@echo "Examples. If you don't know what to do, you likely want to run: "
	@echo ""
	@echo "make build ARCH=x86-64    (This is for 64-bit systems)"
	@echo "make build ARCH=x86-32    (This is for 32-bit systems)"
	@echo ""

.PHONY: build profile-build
build:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) config-sanity
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) all

profile-build:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) config-sanity
	@echo ""
	@echo "Step 0/4. Preparing for profile build."
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) $(profile_prepare)
	@echo ""
	@echo "Step 1/4. Building executable for bench ..."
	@touch *.cpp *.h
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) $(profile_make)
	@echo ""
	@echo "Step 2/4. Running bench for pgo-build ..."
	@$(PGOBENCH) > /dev/null
	@echo ""
	@echo "Step 3/4. Building final executable ..."
	@touch *.cpp
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) $(profile_use)
	@echo ""
	@echo "Step 4/4. Deleting profile data ..."
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) $(profile_clean)

strip:
	strip $(EXE)

install:
	-mkdir -p -m 755 $(BINDIR)
	-cp $(EXE) $(BINDIR)
	-strip $(BINDIR)/$(EXE)

clean:
	$(RM) $(EXE) $(EXE).exe *.o .depend *~ core bench.txt *.gcda

default:
	help

### ==========================================================================
### Section 5. Private targets
### ==========================================================================

all: $(EXE) .depend

config-sanity:
	@echo ""
	@echo "Config:"
	@echo "debug: '$(debug)'"
	@echo "optimize: '$(optimize)'"
	@echo "arch: '$(arch)'"
	@echo "os: '$(os)'"
	@echo "bits: '$(bits)'"
	@echo "prefetch: '$(prefetch)'"
	@echo "bsfq: '$(bsfq)'"
	@echo "popcnt: '$(popcnt)'"
	@echo "sse: '$(sse)'"
	@echo "pext: '$(pext)'"
	@echo ""
	@echo "Flags:"
	@echo "CXX: $(CXX)"
	@echo "CXXFLAGS: $(CXXFLAGS)"
	@echo "LDFLAGS: $(LDFLAGS)"
	@echo ""
	@echo "Testing config sanity. If this fails, try 'make help' ..."
	@echo ""
	@test "$(debug)" = "yes" || test "$(debug)" = "no"
	@test "$(optimize)" = "yes" || test "$(optimize)" = "no"
	@test "$(arch)" = "any" || test "$(arch)" = "x86_64" || test "$(arch)" = "i386" || \
	 test "$(arch)" = "ppc64" || test "$(arch)" = "ppc" || test "$(arch)" = "armv7"
	@test "$(os)" = "any"
	@test "$(bits)" = "32" || test "$(bits)" = "64"
	@test "$(prefetch)" = "yes" || test "$(prefetch)" = "no"
	@test "$(bsfq)" = "yes" || test "$(bsfq)" = "no"
	@test "$(popcnt)" = "yes" || test "$(popcnt)" = "no"
	@test "$(sse)" = "yes" || test "$(sse)" = "no"
	@test "$(pext)" = "yes" || test "$(pext)" = "no"
	@test "$(comp)" = "gcc" || test "$(comp)" = "icc" || test "$(comp)" = "mingw" || test "$(comp)" = "clang"

$(EXE): $(OBJS)
	$(CXX) -o $@ $(OBJS) $(LDFLAGS)

gcc-profile-prepare:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) gcc-profile-clean

gcc-profile-make:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) \
	EXTRACXXFLAGS='-fprofile-generate' \
	EXTRALDFLAGS='-lgcov' \
	all

gcc-profile-use:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) \
	EXTRACXXFLAGS='-fprofile-use' \
	EXTRALDFLAGS='-lgcov' \
	all

gcc-profile-clean:
	@rm -rf *.gcda *.gcno bench.txt

icc-profile-prepare:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) icc-profile-clean
	@mkdir profdir

icc-profile-make:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) \
	EXTRACXXFLAGS='-prof-gen=srcpos -prof_dir ./profdir' \
	all

icc-profile-use:
	$(MAKE) ARCH=$(ARCH) COMP=$(COMP) \
	EXTRACXXFLAGS='-prof_use -prof_dir ./profdir' \
	all

icc-profile-clean:
	@rm -rf profdir bench.txt

.depend:
	-@$(CXX) $(DEPENDFLAGS) -MM $(OBJS:.o=.cpp) > $@ 2> /dev/null

-include .depend


### ==========================================================================
### Section 6. Non-standard targets
### ==========================================================================

hpux:
	$(MAKE) \
	CXX='/opt/aCC/bin/aCC -AA +hpxstd98 -mt +O3 -DNDEBUG -DNO_PREFETCH' \
	CXXFLAGS="" \
	LDFLAGS="" \
	all


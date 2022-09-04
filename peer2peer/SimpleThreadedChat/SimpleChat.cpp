// SimpleChat.cpp : Defines the class behaviors for the application.

// Written by Marat Bedretdinov (maratb@hotmail.com)
// Copyright (c) 2000.
//
// This code may be used in compiled form in any way you desire. This
// file may be redistributed unmodified by any means PROVIDING it is 
// not sold for profit without the authors written consent, and 
// providing that this notice and the authors name is included. 
//
// If the source code in  this file is used in any commercial application 
// then acknowledgement must be made to the author of this file 
// and permissions to use this file are requested from the author
//
// (in whatever form you wish).// This file is provided "as is" with no expressed or implied warranty.
// The author accepts no liability if it causes any damage whatsoever.
// It's free - so you get what you pay for.//


#include "stdafx.h"
#include "SimpleChat.h"
#include "SimpleChatDlg.h"
using namespace std;
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSimpleChatApp

BEGIN_MESSAGE_MAP(CSimpleChatApp, CWinApp)
	//{{AFX_MSG_MAP(CSimpleChatApp)
	ON_THREAD_MESSAGE(UWM_TEST_MESSAGE, OnTestMessage)
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

void CSimpleChatApp::OnTestMessage(WPARAM wParam, LPARAM)
{
}


/////////////////////////////////////////////////////////////////////////////
// CSimpleChatApp construction

#include "NetMessage.h"

CSimpleChatApp::CSimpleChatApp()
{
// all messages classes
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CSimpleChatApp object

CSimpleChatApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CSimpleChatApp initialization

BOOL CSimpleChatApp::InitInstance()
{
  vector<int> pVec= vector<int>();
  vector<int> vecInt;
  vecInt.push_back(0);
  vecInt.push_back(1);
  pVec = (vector<int>)vecInt;
  int n1 = (((vector<int>)pVec))[0];
  int n2 = (((vector<int>)pVec))[1];

	AfxEnableControlContainer();
    AfxInitRichEdit(); 
// init WinSock
	CNetSockConnection::InitWinSock();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.
	
#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif

	CSimpleChatDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with Cancel
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}

int CSimpleChatApp::Run() 
{
	// TODO: Add your specialized code here and/or call the base class
	
	return CWinApp::Run();
}

BOOL CSimpleChatApp::OnIdle(LONG lCount) 
{
	// TODO: Add your specialized code here and/or call the base class
	
	return CWinApp::OnIdle(lCount);
}


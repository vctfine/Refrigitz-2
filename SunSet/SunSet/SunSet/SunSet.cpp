/*Sun set Open Gl. Computer Grpahics Lesson Studing*/
/*Ramin Edjlal. Urmia. Iran*/
/*If we use from class axularations we can optain very useful Sunset.
Wehn this axularations sets then envirounment seems to be useful.
+But the class is not to be the classmate.
+Excucusing the Sunset Is very Reality.
The Low Axulations is limit of Knowledge of Compliler.
+Compliler Has A DLL And Lib And H Can be extended.
+Why to be Harmfule.
Harmfule has very Death Ones.
+Permite Is not yesterday.
+Sares is a salt one.
Registartion is Permited.
Documentation has very problems.
Respolsibility is not be good.
Deases of Code is not allowed.
Salty is of do appologize.
Monye is of Time explaining.
The code was is open.
1392/10/26
Time of Georrgian 2014/16/1
Breaking is of Onlining.
Autehrs have the responsibility.
Exiting has doing the work.
Mistakes has very harmfuls.
The problemes is very low.
the Simulatounouse has very useful knowledge.
Teh news has very deliisouseouse.
This line should be corrected.
Teh key is found.
+After This Knowledges the nkowing Hakkim key Was Missed.The Responsibility was not be illustarted Knowingly.
+The Key was Brings out.
+The Code Used bu one master.
+You Can not Send this Information Out.
+The Correction Was Done.
+The Game Paying was be Usefule.
1392/10/26

*/
#pragma once
#include <math.h>
#include <string.h>
#include <string>
#include <vector>

using namespace std;
class Mass
{
public:
    Mass()
    {
    }
    int i = 0;
    double M = 0;
    double X = 0, Y = 0, Z = 0;
    Mass(double m, double x, double y, double z, int ii)
    {
        i = ii;
        M = m;
        X = x;
        Y = y;
        Z = z;
    }
}; 
class MassPertubation
{
public:
    MassPertubation()
    {
    }
    double M1 = 0, M2 = 0;
    double R = 0;
    double a = 0, b = 0, c = 0;

    MassPertubation(Mass* MM1, Mass* MM2)
    {
        M1 = MM1->M;
        M2 = MM2->M;
        R = sqrt(pow(MM1->X - MM2->X, 2) + pow(MM1->Y - MM2->Y, 2) + pow(MM1->Z - MM2->Z, 2));
        a = MM1->X - MM2->X;
        b = MM1->Y - MM2->Y;
        c = MM1->Z - MM2->Z;
    }

};

 class Pertubsation
{
public:
    Pertubsation() {

    }
     int factrial(int n)
    {
        if (n <= 1)
            return 1;
        return n * factrial(n - 1);
    }
     int pertubsation(int n, int m)
    {
        if (n < m)
            return 0;
        return factrial(n) * factrial(n - m) / factrial(m);
    }
}; 
class ResultOfGravitationalForces
{
 
public:
    ResultOfGravitationalForces()
    {
    }
    double* GetResults(double x[], double y[], double z[], double m[], int N)
    {
        double* result = new double[3];
        Mass** masses = nullptr;
        *masses = new Mass[3];

        for (int i = 0; i < N; i++)
        {
            masses[i] = new Mass(m[i], x[i], y[i], z[i], i);
        }
        int NP = (new Pertubsation())->pertubsation(N, 2);
        if (NP > 0)
        {
            int k = 0;
            MassPertubation** maassespertubation = nullptr;
            *maassespertubation = new MassPertubation[NP];
            std::vector<int*> ZZ = std::vector<int*>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (masses[i]->i != masses[j]->i && (!ExistPairInList(i, j, ZZ)))
                    {
                        int* a = new int[2];
                        a[0] = i;
                        a[1] = j;
                        ZZ.push_back(a);
                        maassespertubation[k] = new MassPertubation(masses[i], masses[j]);
                        k++;
                    }
                }
            }
            NP = k;
            double G = 6.75 * pow(10, -11);
            double X = 0, Y = 0, Z = 0;
            for (int i = 0; i < NP; i++)
            {
                X += (maassespertubation[i]->a * G * (maassespertubation[i]->M1 * maassespertubation[i]->M2) / pow(maassespertubation[i]->R, 2));
                Y += (maassespertubation[i]->b * G * (maassespertubation[i]->M1 * maassespertubation[i]->M2) / pow(maassespertubation[i]->R, 2));
                Z += (maassespertubation[i]->c * G * (maassespertubation[i]->M1 * maassespertubation[i]->M2) / pow(maassespertubation[i]->R, 2));
            }
            result[0] = X;
            result[1] = Y;
            result[2] = Z;
        }
        return result;
    }

    static bool ExistPairInList(int i, int j, std::vector<int*> z)
    {
        bool Ex = false;
        for (int f = 0; f < (int)z.size(); f++)
        {
            if (z[f][0] == i && z[f][1] == j)
                return true;
            if (z[f][0] == j && z[f][1] == i)
                return true;
        }
        return Ex;
    }
};

#pragma once
#include <gl/glut.h>


#include <string.h>
#include <math.h>
#include <stdlib.h>


//#include "SunSet.h"

/*Initiate Global Varibles*/
static float year0 = 0, day0 = 0;
static float year1 = 0, day1 = 0;
static float year2 = 0, day2 = 0;
static float year3 = 0, day3 = 0;
static float year4 = 0, day4 = 0;
static float year5 = 0, day5 = 0;
static float year6 = 0, day6 = 0;
static float year7 = 0, day7 = 0;
static float year8 = 0, day8 = 0;
static double X[10];
static double Y[10];
static double Z[10];
static double M[10];
double* result;
GLfloat light_diffuse[] =
{1.0, 1.0, 1.0, 1.0};
GLfloat light_position[] =
{0.0, 0.0, 0.0, 0.0};
float x=45.0;
float y=1.0;
float z=5.0;
char S[10000];
bool Draw = true;

ResultOfGravitationalForces *h;
/*Out a text to graphics */
void output(GLfloat x, GLfloat y, char *text)
{

	
 /*Intiate local varibles*/
  char *j;

  /*Push Matrix state*/
  glPushMatrix();
  glTranslatef(x, y, 0);
  for (j = text; *j; j++)
  /*Out every text character staring*/
  glutStrokeCharacter(GLUT_STROKE_ROMAN, *j);

  /*Pop Martix*/
  glPopMatrix();
}
void init(void) 
{
    result = new double[3];
    result[0] = 0.0;
    result[1] = 0.0;
    result[3] = 0.0;
	for (int i = 0; i < 9; i++)
	{
		X[i] = 0;
		Y[i] = 0;
		Z[i] = 0;
		M[i] = 1;//Suppose
	}
	/*Initiate OpenGl*/
   glClearColor (0.0, 0.0, 0.0, 0.0);
   glEnable(GL_LIGHTING);
   glEnable(GL_LIGHT0);
   glEnable(GL_DEPTH_TEST);
}
char* ConvertDoubleToChar(double number)
{
    char buf[100000];
    sprintf_s(buf, "%.1f", number);
    return buf;
}
void display(void)
{
     /*Display Function*/
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    /*Push Matrix*/
    glPushMatrix();
    /*Lighting varibles*/
    GLfloat light_ambient[] = { 1.0, 1.0, 0.0, 1.0 };

    /*Lightining varibles*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Create Solid Sphere*/
    glutSolidSphere(0.25, 20, 16);   /* draw sun */

    /*Rotate For year period*/
    glRotatef((GLfloat)year0, 0.0, 1.0, 0.0);


    /*Trasfer Sphare*/
    glTranslatef(0.579, 0.0, 0.0);
    X[0] = 0.579 * cos(year0);;
    M[0] = 1;
    /*Rotate for day*/
    glRotatef((GLfloat)day0, 0.0, 1.0, 0.0);

    /*Sphere Drawing*/
    glutSolidSphere(0.00756, 10, 8);    /* draw Atarod planet */

    /*Pop Matrix*/
    glPopMatrix();
    /*Push Matrix*/
    glPushMatrix();

    /*Lightining varibles*/
    light_ambient[0] = 1.0;
    light_ambient[1] = 0.0;
    light_ambient[2] = 0.0;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Rotate for year*/
    glRotatef((GLfloat)year1, 0.0, 1.0, 0.0);

    /*Transfer function*/
    glTranslatef(1.082, 0.0, 0.0);
    X[1] = 1.082 * cos(year1);
    M[1] = 1.660047755536667 * pow(10, -7);
    glRotatef((GLfloat)day1, 0.0, 1.0, 0.0);

    /*Create Sphere*/
    glutSolidSphere(0.02039, 10, 8);    /* draw Zohreh planet */

    /*Pop Matrix*/
    glPopMatrix();
    /*Push Matrix*/
    glPushMatrix();

    /*Lightining variables*/
    light_ambient[0] = 0.0;
    light_ambient[1] = 1.0;
    light_ambient[2] = 0.0;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Roatat for year*/
    glRotatef((GLfloat)year2, 0.0, 1.0, 0.0);

    /*Transfer function*/
    glTranslatef(1.496, 0.0, 0.0);
    X[2] = 1.496 * cos(year2);
    M[2] = 2.447589362073025 * pow(10, -6);
    /*Roatet for day*/
    glRotatef((GLfloat)day2, 0.5, 1.0, 0.0);

    /*Create Sphere*/
    glutSolidSphere(0.02, 10, 8);    /* draw Erthe planet */

    /*Roatat for year*/
    glRotatef((GLfloat)year2, 0.0, 1.0, 0.0);

    /*Trasfer for day*/
    glTranslatef(0.02, 0.0, 0.0);

    /*Roatat for year*/
    glRotatef((GLfloat)day2, 0.0, 1.0, 0.0);

    /*Create Sphare*/
    glutSolidSphere(0.052, 10, 8);    /* draw Moon planet */

    /*Pop Matrix*/
    glPopMatrix();
    /*Push Matrix*/
    glPushMatrix();

    /*Lightining varibales*/
    light_ambient[0] = 1.0;
    light_ambient[1] = 1.0;
    light_ambient[2] = 0.5;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Rotate function*/
    glRotatef((GLfloat)year3, 0.0, 1.0, 0.0);

    /*Trasfer function*/
    glTranslatef(2.279, 0.0, 0.0);
    X[3] = 2.279 * cos(year3);
    M[3] = 3.003167261575587 * pow(10, -6);
    X[4] = 2.279;//Moon
    Y[4] = 0;
    Z[4] = 0;
    M[4] = 3.69513850485144 * pow(10, -8);
    /*Rotate function*/
    glRotatef((GLfloat)day3, 0.0, 1.0, 0.0);

    /*Create Sphere*/
    glutSolidSphere(0.01065, 10, 8);    /* draw Merikh planet */

    /*Pop Matrix*/
    glPopMatrix();
    /*Pop Matrix*/
    glPushMatrix();

    /*Lightining variables*/
    light_ambient[0] = 1.0;
    light_ambient[1] = 0.5;
    light_ambient[2] = 0.5;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Rotate function*/
    glRotatef((GLfloat)year4, 0.0, 1.0, 0.0);

    /*Trasfare function*/
    glTranslatef(7.783, 0.0, 0.0);
    X[5] = 7.783 * cos(year4);
    M[5] = 3.226836257603941 * pow(10, -7);

    /*Rotate function*/
    glRotatef((GLfloat)day4, 0.0, 1.0, 0.0);

    glutSolidSphere(0.224112, 10, 8);    /* draw Zohal planet */

    /*Pop Matrix*/
    glPopMatrix();
    /*Push Matrix*/
    glPushMatrix();

    /*Lightinig variables*/
    light_ambient[0] = 0.5;
    light_ambient[1] = 1.0;
    light_ambient[2] = 0.5;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Roatate function*/
    glRotatef((GLfloat)year5, 0.0, 1.0, 0.0);

    /*Trnsfar Matrix*/
    glTranslatef(14.27, 0.0, 0.0);
    X[6] = 14.27 * cos(year5);
    M[6] = 2.857875421044694 * pow(10, -4);
    /*Rotate function*/
    glRotatef((GLfloat)day5, 0.0, 1.0, 0.0);

    /*Create Sphare*/
    glutSolidSphere(0.588986, 10, 8);    /* draw Suturn planet */

    /*Pop Matrix*/
    glPopMatrix();

    /*Push Matrix*/
    glPushMatrix();

    /*Lightinig variables*/
    light_ambient[0] = 0.5;
    light_ambient[1] = 1.0;
    light_ambient[2] = 0.5;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Roatate function*/
    glRotatef((GLfloat)year6, 0.0, 1.0, 0.0);

    /*Transfar Matrix*/
    glTranslatef(28.71, 0.0, 0.0);
    X[7] = 28.71 * cos(year6);
    M[7] = 0.0054791614297924;

    /*Roatate function*/
    glRotatef((GLfloat)day6, 0.0, 1.0, 0.0);

    /*Create Sphare*/
    glutSolidSphere(0.080148, 10, 8);    /* draw Oranus planet */

    /*Pop Matrix*/
    glPopMatrix();

    /*Push Matrix*/
    /*Push Matrix*/
    glPushMatrix();

    /*Lightining variables*/
    light_ambient[0] = 0.5;
    light_ambient[1] = 1.0;
    light_ambient[2] = 0.5;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Rotate function*/
    glRotatef((GLfloat)year7, 0.0, 1.0, 0.0);

    /*Transfare Matrix*/
    glTranslatef(44.971, 0.0, 0.0);
    X[8] = 44.971 * cos(year7);
    M[8] = 4.36539138303755 * pow(10, -5);
    /*Roatate function*/
    glRotatef((GLfloat)day7, 0.0, 1.0, 0.0);

    /*Create Sphare*/
    glutSolidSphere(0.077654, 10, 8);    /* draw Nepton planet */

    /*Pop Matrix*/
    glPopMatrix();

    /*Push Matrix*/
    glPushMatrix();

    /*Lightinig variables*/
    light_ambient[0] = 0.5;
    light_ambient[1] = 1.0;
    light_ambient[2] = 0.5;
    light_ambient[3] = 1.0;

    /*Lightining function*/
    glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);

    /*Roatate function*/
    glRotatef((GLfloat)year8, 0.0, 1.0, 0.0);

    /*Transfare Matrix*/
    glTranslatef(59.13, 0.0, 0.0);
    X[9] = 59.13 * cos(year8);
    M[9] = 5.149565129958273 * pow(10, -5);

    /*Roatate function*/
    glRotatef((GLfloat)day8, 0.0, 1.0, 0.0);

    /*Create Sphare*/
    glutSolidSphere(0.00713, 10, 8);    /* draw Ploto planet */

    /*Pop Matrix*/
    glPopMatrix();

    /*Push Matrix*/
    glPushMatrix();


    /*Push Atrribute of Function*/
    glPushAttrib(GL_ENABLE_BIT);

    /*Disable some feature
    glDisable(GL_DEPTH_TEST);
    glDisable(GL_LIGHTING);

    /*Configure Matrix function*/
    glMatrixMode(GL_PROJECTION);

    /*Push Matrix*/
    glPushMatrix();

    /*Load Identity*/
    glLoadIdentity();
    /*Some function*/
    gluOrtho2D(0, 1500, 0, 1500);

    /*Configure Matrix Mode*/
    glMatrixMode(GL_MODELVIEW);

    /*Push Matrix*/
    glPushMatrix();

    /*Load Identity*/
    glLoadIdentity();

    /*Configure 3D Function*/
    glColor3f(0.0, 1.0, 0.0);
    /* Rotate text slightly to help show jaggies*/
    glRotatef(4, 0.0, 0.0, 1.0);

    /*out put Auther name*/
    //output(2000, 225, "Ramin Edjlal.");

    /*Disable some feature*/
    glDisable(GL_LINE_SMOOTH);
    glDisable(GL_BLEND);

    /*Student number output*/
    //output(160, 100, "880879004");
    output(70, 100, S);

    /*Pop Matrix*/
   glPopMatrix();

   /*Matrix Mode*/
   glMatrixMode(GL_PROJECTION);

   /*Pop Matrix*/
   glPopMatrix();

   /*Pop Attribute*/
   glPopAttrib();

  /*Matrix Mode*/
  glMatrixMode(GL_MODELVIEW);

  /*Swap Buffer function*/
  glutSwapBuffers();
}

void reshape (int w, int h)
{
	/*Reshape function*/
   glViewport (0, 0, (GLsizei) w, (GLsizei) h); 
   glMatrixMode (GL_PROJECTION);
   glLoadIdentity ();
   gluPerspective(45.0, (GLfloat) w/(GLfloat) h, 1.0, 20.0);
   glMatrixMode(GL_MODELVIEW);
   glLoadIdentity();
   gluLookAt (3.5,3.5,7.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
}

void keyboard (unsigned char key, int x, int y)
{
	/*KeayBoard*/
   switch (key) {
      case 'd':
         day0 = (int)(day0 + 1) % 360;
		 day1 = (int)(day1 + 2) % 360;
		 day2 = (int)(day2 + 3) % 360;
		 day3 = (int)(day3 + 4) % 360;
		 day4 =(int) (day4 + 5) % 360;
		 day5 = (int)(day5 + 6) % 360;
		 glutPostRedisplay();
         break;
      case 'D':
         day0 = (int)(day0 + 1) % 360;
		 day1 = (int)(day1 + 2) % 360;
		 day2 = (int)(day2 + 3) % 360;
		 day3 = (int)(day3 + 4) % 360;
		 day4 = (int)(day4 + 5) % 360;
		 day5 = (int)(day5 + 6) % 360;
		 glutPostRedisplay();
         break;
      case 'a':
         year0 = (int)(year0 + 36) % 360;
	     year1 = (int)(year1 + 7) % 360;
		 year2 = (int)(year2 + 5) % 360;
		 year3 = (int)(year3 + 3) % 360;
		 year4 = (int)(year4 + 2) % 360;
		 year5 = (int)(year5 + 1) % 360;
         glutPostRedisplay();
         break;
      case 'A':
         year0 = (int)(year0 + 36) % 360;
	     year1 = (int)(year1 + 7) % 360;
		 year2 = (int)(year2 + 5) % 360;
		 year3 = (int)(year3 + 3) % 360;
		 year4 = (int)(year4 + 2) % 360;
		 year5 = (int)(year5 + 1) % 360;
         glutPostRedisplay();
         break;
	  case 'f':
         day0 = (int)(day0 + 1) % 360;
		 day1 = (int)(day1 + 2) % 360;
		 day2 = (int)(day2 + 3) % 360;
		 day3 = (int)(day3 + 4) % 360;
		 day4 = (int)(day4 + 5) % 360;
		 day5 = (int)(day5 + 6) % 360;
		 year0 = (int)(year0 + 36) % 360;
	     year1 = (int)(year1 + 7) % 360;
		 year2 = (int)(year2 + 5) % 360;
		 year3 = (int)(year3 + 3) % 360;
		 year4 = (int)(year4 + 2) % 360;
		 year5 = (int)(year5 + 1) % 360;
         glutPostRedisplay();
         break;   
	  case 'r':
          Draw = false;
          result=h->GetResults(X, Y, Z, M, 10);
          result[0] = result[0] * 1989100000.0 * pow(10, 21);
          result[1] = result[1] * 1989100000.0 * pow(10, 21);
          result[2] = result[2] * 1989100000.0 * pow(10, 21);
          Draw = true;
          if (Draw)
          {
              S[0] = 0;
              strcat_s(S, "R:");
              if (result != nullptr)
              {

                  strcat_s(S, "X:");
                  strcat_s(S, ConvertDoubleToChar(result[0]));
                  strcat_s(S, "Y:");
                  strcat_s(S, ConvertDoubleToChar(result[1]));
                  strcat_s(S, "Z:");
                  strcat_s(S, ConvertDoubleToChar(result[2]));
                  strcat_s(S, " N");
                  strcat_s(S, "\0");
              }
              //output(70, 100, S);
              printf_s(S);
          } glutPostRedisplay();
          break;
     default:
         break;
   }
}

GLvoid Timer( int value )
{
	/*Timer function*/
   if( value ) glutPostRedisplay();
   glutTimerFunc(40,Timer,value);
}
static void _Timer(int value)
{
	
  /* increment angle */
         day0 = (int)(day0 + 1) % 360;
		 day1 = (int)(day1 + 2) % 360;
		 day2 = (int)(day2 + 3) % 360;
		 day3 = (int)(day3 + 4) % 360;
		 day4 = (int)(day4 + 5) % 360;
		 day5 = (int)(day5 + 6) % 360;
		 day6 = (int)(day5 + 6) % 360;
		 day7 = (int)(day5 + 8) % 360;
		 year0 = (year0 + 44.51 ) ;
	     year1 = (year1 + 27.38 ) ;
		 year2 = (year2 + 14.55) ;
		 year3 = (year3 + 2.31)  ;
		 year4 = (year4 + 0.93)  ;
		 year5 = (year5 +0.33 ) ;
		 year6 = (year6 + 0.58)  ;
		 year7 = (year7 + 0.01)  ;
		 year8 = (year8 + 0.01)  ;
		 if(year0>360)
			 year0=(int)year0%360;
   
		 if(year1>360)
			 year1=(int)year1%360;
   
		 if(year2>360)
			 year2=(int)year2%360;
   	
		 if(year3>360)
			 year3=(int)year3%360;
   
    	 if(year4>360)
			 year4=(int)year4%360;
   
		 if(year5>360)
			 year5=(int)year5%360;
   
	     if(year6>360)
			 year6=(int)year6%360;
   
	     if(year7>360)
			 year7=(int)year7%360;
   
    	 if(year8>360)
			 year8=(int)year8%360;
		 
       

  /* send redisplay event */
  glutPostRedisplay();

  /* call this function again in 10 milliseconds */
  glutTimerFunc(50, _Timer, 0);
}

int main(int argc, char** argv)
{
	h = new ResultOfGravitationalForces();
	/*Main functinon*/
   glutInit(&argc, argv);

   /*Initate Display Mode*/
   glutInitDisplayMode (GLUT_DOUBLE | GLUT_RGB);

   /*Initate Windows size*/
   glutInitWindowSize (1600, 900); 

   /*Initiate Windows position*/
   glutInitWindowPosition (100, 100);

   /*Create a window*/
   glutCreateWindow (argv[0]);

   /*Initiate*/
   init ();
   glutKeyboardFunc(keyboard);
   /*Displaye function call*/
   glutDisplayFunc(display); 

   /*Reshape function*/
   glutReshapeFunc(reshape);

  /*Timer function*/
   glutTimerFunc(10, _Timer, 0);

   /*Main loop*/
   glutMainLoop();
   return 0;
}


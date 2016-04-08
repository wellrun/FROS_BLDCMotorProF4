/********************************************************************************
  * @FileName   sal_KalmanFilter.h
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/11/28
  * @Brief      Ëã·¨³éÏó²ã,¿¨¶ûÂüÂË²¨(KF)
  *******************************************************************************/
#ifndef   _SAL_KALMANFILTER_H_
#define   _SAL_KALMANFILTER_H_
/*#includes**********************************************************************/
#include "math.h"

typedef struct _KFParamStruct
{
    float x; /*state*/
    float A; /*x(n) = A*x(n-1)+u(n),u(n)~N(0,q)*/
    float H; /*z(n) = H*x(n)+w(n),w(n)~N(0,r)*/
    float q; /*predict noise convariance*/
    float r; /*measure noise convariance*/
    float p; /*estiomated error convariance*/
    float kg;/*kalman filter gain */
}KFParamStruct;

void KF_Simple_Init(KFParamStruct* myStruct,float myX,float myP,float myQ,float myR);
float KF_Simple_Calculate(KFParamStruct* myStruct,float zMeasure);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

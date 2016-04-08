/********************************************************************************
  * @FileName   sal_KalmanFilter.c
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/11/28
  * @Brief      算法抽象层,卡尔曼滤波(KF)
  *******************************************************************************/
/*#includes**********************************************************************/
#include "sal_KalmanFilter.h"

/*
 *@<function name=> KF_Simple_Init() </function>
 *@<summary>
    简单的一维变量Kalman滤波的参数初始化,默认A=H=1
 *@</summary>
 *@<param name="myStruct">kalman参数结构体</param>
 *@<param name="myX"> 初始化状态量</param>
 *@<param name="myP">初始化预测噪声协方差</param>
 *@<param name="myQ"> 初始化测量噪声协方差</param>
 *@<param name="myR"> 初始化估计噪声协方差</param>
 *@<returns> null </returns>
*/
void KF_Simple_Init(KFParamStruct* myStruct,float myX,float myP,float myQ,float myR)
{
    myStruct->x = myX;
    myStruct->p = myP;
    myStruct->q = myQ;
    myStruct->r = myR;
    myStruct->A = 1;
    myStruct->H = 1;
    myStruct->kg = 0;
}
/*
 *@<function name=> KF_Simple_Calculate() </function>
 *@<summary>
    简单的一维变量Kalman滤波计算
 *@</summary>
 *@<param name="myStruct">kalman参数结构体</param>
 *@<param name="zMeasure">测量量</param>
 *@<returns> 滤波后的最优估计值 </returns>
*/
float KF_Simple_Calculate(KFParamStruct* myStruct,float zMeasure)
{
    /*predict processing*/
    myStruct->x = myStruct->A * myStruct->x;
    myStruct->p = myStruct->A*myStruct->p*myStruct->A + myStruct->q;/* p(n|n-1)=A^2*p(n-1|n-1)+q */
    /*Measure processing*/
    myStruct->kg = myStruct->p * myStruct->H/(myStruct->H*myStruct->p*myStruct->H + myStruct->r);
    myStruct->x = myStruct->x +myStruct->kg*(zMeasure - myStruct->H*myStruct->x);
    myStruct->p = (1 - myStruct->kg*myStruct->H)*myStruct->p;
    return myStruct->x;
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */
                                                             

/********************************************************************************
 *@FileName    sal_PID.h
 *@Author      Johnbee
 *@Version     V0.0.1
 *@Date        2015/11/24
 *@Brief       算法抽象层,PID算法
 *******************************************************************************/
#ifndef   _SAL_PID_H_
#define   _SAL_PID_H_
/*#includes*********************************************************************/
#include "math.h"

typedef struct _PIDTypeDef  //位置式PID
{
	float fd;   /*前馈*/
	float kp;
	float ki;
	float kd;
	float expect_value;  /*期望值,为0时表示在最中间*/
	float now_value;     /*实时值*/
	float delta_value;   /*微分项*/
	float sum_value;     /*积分项*/
	float now_error;     /*本次的误差值*/
	float last_error;   /*上一次的误差值*/
	float max_value;
	float min_value;
	double ref;        /*输出值*/
}PIDTypeDef;


void PID_Cal(PIDTypeDef* my_PID,float myExpectValue,float myNowValue,float inteRegion);
void Set_PID_Param(PIDTypeDef* my_pid,float fd,float kp,float ki,float kd,float max,float min);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

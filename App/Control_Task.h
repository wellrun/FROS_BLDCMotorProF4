/********************************************************************************
  * @FileName   Control_Task.h
  * @Author     Johnbee
  * @Version    V1.0.0
  * @Date       2015/11/23
  * @Brief      电机控制任务
  *******************************************************************************/
#ifndef   _CONTROL_TASK_H_
#define   _CONTROL_TASK_H_
/*#includes**********************************************************************/
#include "app.h"
#include "sal_PID.h"

typedef struct _MotorParamStruct
{
    float speed;//速度
    float lenth;//位移
}MotorParamStruct;  //电机参数结构体


extern MotorParamStruct   Iface_MyMotor;
extern PIDTypeDef  PID_Loction,PID_Speed,PID_Current;  //位置,速度,电流环

void Control_Task_Create(u8 myPrio);
static void Control_Task(void *pdata);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

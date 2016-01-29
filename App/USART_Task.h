/***********************************************************************************************
 *@FileName   USART_Task.h
 *@Version    V0.0.0.1
 *@Author     Johnbee
 *@Date       2015/07/31
 *@Brief      串口发送任务
 ***********************************************************************************************/
#ifndef   _USART_TASK_H_
#define   _USART_TASK_H_
/*#include*************************************************************************************/
#include "bsp_Init.h"

void USART_Task_Create(u8 myPrio);
static void USART_Task(void *pdata);

#endif
/**************************End of this file***************************************
 


                                          Copyright @JohnBee */

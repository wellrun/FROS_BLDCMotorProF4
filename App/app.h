/********************************************************************************
 *@FileName    app.h
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/10/02
 *@Brief       用于各种硬件初始化
 *******************************************************************************/
#ifndef     _APP_H_
#define     _APP_H_

/*#includes*********************************************************************/
#ifdef _STM32F10x_
    #include <stm32f10x.h>
#endif
#ifdef _STM32F4XX_
    #include <stm32f4xxx.h>
#endif

#include "includes.h"
#include "bsp_init.h"
#include "MainTask.h"
#include "Control_Task.h"
#include "USART_Task.h"
#include "EncoderTask.h"

void Start_Task_Create(void);
void Start_Task(void *pdata); //开始任务

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

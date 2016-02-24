/********************************************************************************
 *@FileName    bsp_HallTIM.h
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2016/02/23
 *@Brief       配置Hall接口定时器
 *******************************************************************************/
#ifndef   _BSP_HALLTIM_H_
#define   _BSP_HALLTIM_H_

/*#includes*********************************************************************/
#include "bsp_init.h"


void Hall_TimerConfig(void);
void Hall_TIM_NVIC_Config(u8 preemPriority, u8 subPriority);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

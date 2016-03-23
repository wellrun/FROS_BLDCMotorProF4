/********************************************************************************
 *@FileName    bsp_Commutation.h
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/02/23
 *@Brief       µç»ú»»Ïà
 *******************************************************************************/
#ifndef   _BSP_COMMUTATION_H_
#define   _BSP_COMMUTATION_H_


/*#includes*********************************************************************/
#include "bsp_init.h"

void Hall_GPIO_Init(void);
void EXTI4_NVIC_Config(u8 preemPriority,u8 subPriority);
void EXTI9_5_NVIC_Config(u8 preemPriority,u8 subPriority);
void Hall_PrepareCommutation(void);
void Set_MotorSpeed(float speed);
void Set_MotorState(u8 myState);
static u16 GrayCode2Decimal(u16 x);
static u8 HallCode2Decimal(u8 x);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */


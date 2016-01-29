/*******************************************************************************************************
  * @FileName    bsp_CAN.h
  * @Author      Johnbee
  * @Version     V0.0.1
  * @Date        2015/11/23
  * @Brief       CAN总线配置文件  
  ******************************************************************************************************/
#ifndef       _BSP_CAN_H_
#define       _BSP_CAN_H_
/*#include**********************************************************************************************/
#include "bsp_Init.h"



void Bsp_CAN_Init(void);
void CAN1_RX_NVIC(u8 preemPriority,u8 subPriority);
static void My_CAN_Init(CAN_TypeDef* CANx);

#endif
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */






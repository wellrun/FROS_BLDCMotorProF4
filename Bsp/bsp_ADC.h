/*********************************************************************************
 *@FileName   bsp_ADC.h
 *@Version    V0.0.0.1
 *@Author     Johnbee
 *@Date       2015/11/16
 *@Brief      ADC配置
 *********************************************************************************/
#ifndef   _BSP_ADC_H_
#define   _BSP_ADC_H_

/*#include************************************************************************/
#include "bsp_Init.h"

#define  ADC_Converted_Num1    (30u)
#define  ADC_Converted_Num2    (20u)

extern uint16_t  ADC_USED_ConvertedValue1[ADC_Converted_Num1];//缓冲区1
extern uint16_t  ADC_USED_ConvertedValue2[ADC_Converted_Num2];//缓冲区2
extern float Current_Value;
extern u8    Current_CalibrateState;  //启动时电流环零点校准标志

void Bsp_ADC_Init(void);
void DMA_Phase_ADC_NVIC(u8 prePriority,u8 subPriority);
void DMA_Current_ADC_NVIC(u8 prePriority,u8 subPriority);

float Get_Current_ADC_Value(void);
float ADvalue2Voltag(float adValue);
float ADvalue2Current(float adValue);

static void ADC_Start(void);
static void Phase_ADC_GPIO_Config(void);
static void Phase_ADC_Config(void);
static void Phase_ADC_DMA_Config(void);
static void Current_ADC_GPIO_Config(void);
static void Current_ADC_Config(void);
static void Current_ADC_DMA_Config(void);

#endif
/**************************End of this file***************************************
 


                                          Copyright @JohnBee */

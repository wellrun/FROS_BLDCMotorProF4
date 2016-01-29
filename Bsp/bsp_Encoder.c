/********************************************************************************
 *@FileName    bsp_Encoder.c
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/11/23
 *@Brief       配置编码器
 *******************************************************************************/
/*#includes*********************************************************************/
#include "bsp_Encoder.h"

/*#define***********************************************************************/
#ifdef  _STM32F10x_
#define Encoder_TIM                TIM2
#define RCC_Encoder_TIM            RCC_APB1Periph_TIM2
#define Encoder_A_Port             GPIOA
#define Encoder_A_Pin              GPIO_Pin_0
#define RCC_Encoder_A_Port         RCC_APB2Periph_GPIOA | RCC_APB2Periph_AFIO
#define Encoder_B_Port             GPIOA
#define Encoder_B_Pin              GPIO_Pin_1
#define RCC_Encoder_B_Port         RCC_APB2Periph_GPIOA | RCC_APB2Periph_AFIO
#endif
#ifdef  _STM32F4xx_
#define Encoder_TIM                TIM4
#define RCC_Encoder_TIM            RCC_APB1Periph_TIM4
#define Encoder_A_Port             GPIOB
#define Encoder_A_Pin              GPIO_Pin_6
#define Encoder_A_PinSource        GPIO_PinSource6
#define Encoder_A_AF               GPIO_AF_TIM4
#define RCC_Encoder_A_Port         RCC_AHB1Periph_GPIOB 
#define Encoder_B_Port             GPIOB
#define Encoder_B_Pin              GPIO_Pin_7
#define Encoder_B_PinSource        GPIO_PinSource7
#define Encoder_B_AF               GPIO_AF_TIM4
#define RCC_Encoder_B_Port         RCC_AHB1Periph_GPIOB
#endif
#define   Encoder_Init_Value     (30000u)
#define   Encoder_ARR_Value      (60000u)

/*全局变量声明********************************************************************/
//float Encoder_Lenth = 0;//编码器位移

/*********************************************************************************
 * @函数名称  Bsp_Encoder_Config()
 * @函数功能  配置定时器捕捉编码器
 * @入口参数  无
 * @出口参数  无
*********************************************************************************/
void Bsp_Encoder_Config(void)
{
    RCC_APB1PeriphClockCmd(RCC_Encoder_TIM, ENABLE);  //使能定时器9的时钟
    Encoder_GPIO_Config();
    TIM_EncoderInterfaceConfig(Encoder_TIM, TIM_EncoderMode_TI12, TIM_ICPolarity_Rising, TIM_ICPolarity_Rising);

    Encoder_TIM->ARR = Encoder_ARR_Value;  //重装载寄存器
    Encoder_TIM->CNT = Encoder_Init_Value;   //计数寄存器
    TIM_Cmd(Encoder_TIM, ENABLE);
}
/*
 *@ <function name=> Set_PID_Param() </function>
 *@ <summary>
    Get 编码器的增量值
 *@ </summary>
 *@ <returns> null </returns>
*/
s16 Get_Encoder_Value(void)
{
    s16 temp = Encoder_TIM->CNT - Encoder_Init_Value;
    Encoder_TIM->CNT = Encoder_Init_Value;
    return temp;
}
/*********************************************************************************
 * @函数名称  Encoder_GPIO_Config()
 * @函数功能  配置编码器GPIO口
 * @入口参数  无
 * @出口参数  无
*********************************************************************************/
static void Encoder_GPIO_Config(void)
{
#ifdef _STM32F4xx_ 
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_AHB1PeriphClockCmd(RCC_Encoder_A_Port | RCC_Encoder_B_Port, ENABLE); //开时钟

    GPIO_InitStructure.GPIO_Pin  = Encoder_A_Pin;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;   //复用模式
    GPIO_InitStructure.GPIO_OType = GPIO_OType_OD; //推挽输出
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;    //上拉
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
    GPIO_Init(Encoder_A_Port, &GPIO_InitStructure);

    GPIO_InitStructure.GPIO_Pin  = Encoder_B_Pin;
    GPIO_Init(Encoder_B_Port, &GPIO_InitStructure);

    GPIO_PinAFConfig(Encoder_A_Port, Encoder_A_PinSource, Encoder_A_AF); //设置定时器复用功能
    GPIO_PinAFConfig(Encoder_B_Port, Encoder_B_PinSource, Encoder_B_AF); //设置定时器复用功能
#endif
#ifdef _STM32F10x_
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_APB1PeriphClockCmd(RCC_Encoder_A_Port | RCC_Encoder_B_Port, ENABLE); //开时钟

    GPIO_InitStructure.GPIO_Pin  = Encoder_A_Pin;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;   //复用模式
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(Encoder_A_Port, &GPIO_InitStructure);

    GPIO_InitStructure.GPIO_Pin  = Encoder_B_Pin;
    GPIO_Init(Encoder_B_Port, &GPIO_InitStructure);

#endif
}

/****************** end of this file ********************************************


                                                             Copyright @JohnBee */


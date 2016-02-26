/********************************************************************************
 *@FileName    bsp_HallTIM.c
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2016/02/23
 *@Brief       配置Hall接口定时器
 *******************************************************************************/
/*#includes*********************************************************************/
#include "bsp_HallTIM.h"

/*#define***********************************************************************/
#define Hall_TIM                        TIM3
#define RCC_Hall_TIM                    RCC_APB1Periph_TIM3
#define Hall_TIM_GPIO                   GPIOC
#define RCC_Hall_TIM_GPIO               RCC_AHB1Periph_GPIOC
#define Hall_TIM_Pin                    GPIO_Pin_6|GPIO_Pin_7|GPIO_Pin_8
#define Hall_TIM_GPIO_AF                GPIO_AF_TIM3
#define Hall_TIM_GPIO_PinSource1        GPIO_PinSource6
#define Hall_TIM_GPIO_PinSource2        GPIO_PinSource7
#define Hall_TIM_GPIO_PinSource3        GPIO_PinSource8

#define Hall_TIM_Pin_Start             (6u)
#define Hall_TIM_IRQn                  TIM3_IRQn


/*
 *@ <function name=>Hall_TimerConfig() </function>
 *@ <summary>
       配置霍尔输入定时器
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void Hall_TimerConfig(void)
{
#ifdef  _STM32F4xx_
    TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
    TIM_ICInitTypeDef        TIM_ICInitStructure;
    TIM_OCInitTypeDef        TIM_OCInitStructure;
    GPIO_InitTypeDef         GPIO_InitStructure;

    RCC_AHB1PeriphClockCmd(RCC_Hall_TIM_GPIO, ENABLE); //开时钟
    RCC_APB1PeriphClockCmd(RCC_Hall_TIM, ENABLE);

    GPIO_InitStructure.GPIO_Pin = Hall_TIM_Pin;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
    GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
    GPIO_Init(Hall_TIM_GPIO, &GPIO_InitStructure);
    
//    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_7;
//    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
//    GPIO_InitStructure.GPIO_OType = GPIO_OType_OD; 
//    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;    
//    GPIO_Init(Hall_TIM_GPIO, &GPIO_InitStructure);
   
    GPIO_PinAFConfig(Hall_TIM_GPIO, Hall_TIM_GPIO_PinSource1, GPIO_AF_TIM3);
    GPIO_PinAFConfig(Hall_TIM_GPIO, Hall_TIM_GPIO_PinSource2, GPIO_AF_TIM3);
    GPIO_PinAFConfig(Hall_TIM_GPIO, Hall_TIM_GPIO_PinSource3, GPIO_AF_TIM3);
    

    TIM_DeInit(Hall_TIM);
    // timer base configuration
    // 126 => 3,5s till overflow ; 285,714kHz TimerClock [36MHz/Prescaler]
    TIM_TimeBaseStructure.TIM_Prescaler = TIM_CKD_DIV1;
    TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
    TIM_TimeBaseStructure.TIM_Period = 65535;
    TIM_TimeBaseStructure.TIM_ClockDivision = 0;
    TIM_TimeBaseStructure.TIM_RepetitionCounter = 0;
    TIM_TimeBaseInit(Hall_TIM, &TIM_TimeBaseStructure);

    // Channel 1 in input capture mode
    // on every TCR edge (build from TI1F_ED which is a HallSensor edge)
    // the timervalue is copied into ccr register and a CCR1 Interrupt
    // TIM_IT_CC1 is fired
    TIM_ICInitStructure.TIM_Channel = TIM_Channel_1;
    TIM_ICInitStructure.TIM_ICPolarity = TIM_ICPolarity_BothEdge;
    // listen to T1, the  HallSensorEvent
    TIM_ICInitStructure.TIM_ICSelection = TIM_ICSelection_TRC;
    // Div:1, every edge
    TIM_ICInitStructure.TIM_ICPrescaler = TIM_ICPSC_DIV1;
    // noise filter: 1111 => 72000kHz / factor (==1) / 32 / 8 -> 281kHz
    // input noise filter (reference manual page 322)
    TIM_ICInitStructure.TIM_ICFilter = 0x01;
    TIM_ICInit(Hall_TIM, &TIM_ICInitStructure);

    // channel 2 can be use for commution delay between hallsensor edge
    // and switching the FET into the next step. if this delay time is
    // over the channel 2 generates the commutation signal to the motor timer
/*   这段代码有毒,开启这段代码后会导致ch2输入寄存器位失效,读出的霍尔序列为错误的
     屏蔽这段代码后使用手动的方法觖发COM事件
    TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM2;
    TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
    TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_High;
    TIM_OCInitStructure.TIM_Pulse = 100; // 1 is no delay; 2000 = 7ms
    TIM_OC2Init(Hall_TIM, &TIM_OCInitStructure);
*/  
    TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_Timing;  
    TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Disable;             
    TIM_OCInitStructure.TIM_Pulse =65535; 
    TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_High;        
    TIM_OC4Init(Hall_TIM,&TIM_OCInitStructure);

    // enable hall sensor
    // T1F_ED will be connected to  HallSensoren Imputs
    // TIM_CH1,TIM_CH2,TIM_CH3
    TIM_SelectHallSensor(Hall_TIM, ENABLE);

    //  TIM_EncoderInterfaceConfig(TIM_TypeDef* TIMx, uint16_t TIM_EncoderMode,
    //  uint16_t TIM_IC1Polarity, uint16_t TIM_IC2Polarity)

    // HallSensor event is delivered with singnal TI1F_ED
    // (this is XOR of the three hall sensor lines)
    // Signal TI1F_ED: falling and rising ddge of the inputs is used
    TIM_SelectInputTrigger(Hall_TIM, TIM_TS_TI1F_ED);

    // On every TI1F_ED event the counter is resetted and update is tiggered
    TIM_SelectSlaveMode(Hall_TIM, TIM_SlaveMode_Reset);

    TIM_SelectMasterSlaveMode(Hall_TIM, TIM_MasterSlaveMode_Enable);
//    TIM_SelectOutputTrigger(Hall_TIM, TIM_TRGOSource_OC1);
    // timer2 output compate signal is connected to TRIGO
//    TIM_SelectOutputTrigger(Hall_TIM, TIM_TRGOSource_OC2Ref);
    
    // clear interrupt flag
    TIM_ClearFlag(Hall_TIM, TIM_FLAG_CC1);   
    // Enable channel1 compate interrupt request
    // TIM_IT_CC1 | TIM_IT_CC2
    TIM_ITConfig(Hall_TIM, TIM_IT_CC1, ENABLE);
    // we use preemption interrupts here,  BLDC Bridge switching and
    // Hall has highest priority

    // -------------------
    // HallSensor is now configured, if BLDC Timer is also configured
    // after enabling timer
    // the motor will start after next overflow of the hall timer because
    // this generates the first startup motor cummutation event
    TIM_Cmd(Hall_TIM, ENABLE);
#endif
}
/*
 *@ <function name=>Hall_TIM_NVIC_Config() </function>
 *@ <summary>
       霍尔接口定时器中断优先级配置
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void Hall_TIM_NVIC_Config(u8 preemPriority, u8 subPriority)
{
    NVIC_InitTypeDef NVIC_InitStructure;
    NVIC_InitStructure.NVIC_IRQChannel = Hall_TIM_IRQn;// 霍尔定时器中断;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = preemPriority;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = subPriority;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);
}
/*
 *@ <function name=> Hall_TIM_IRQPandler() </function>
 *@ <summary>
     hall定时器中断处理子函数
     在stm32f10x_it.c中调用了
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
u8 Temp_value = 0;
u8 value[10] = {0};
void Hall_TIM_IRQPandler(void)
{
    static u8 index = 0,lastvalue = 0;
    if(TIM_GetITStatus(Hall_TIM,TIM_IT_CC1))
    {
        TIM_ClearITPendingBit(Hall_TIM, TIM_IT_CC1);
        Temp_value = Get_HallInputValue();
        if(index < 9)
        {
            if(lastvalue != Temp_value)
            {
                index++;
                value[index] = Temp_value;
            }
        }
        lastvalue = Temp_value;
    

    }
    if(TIM_GetITStatus(Hall_TIM,TIM_IT_CC2))
    {
        TIM_ClearITPendingBit(Hall_TIM, TIM_IT_CC2);
    }

}
/*
 *@ <function name=> Get_HallInputValue() </function>
 *@ <summary>
     获取Hall传感器的值
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> 三个引脚的电平值 </returns>
 */
u8 Get_HallInputValue(void)
{
    u8 ref = 0;
    u16 temp = GPIO_ReadInputData(Hall_TIM_GPIO);
    temp = temp & (Hall_TIM_Pin);
    temp = temp >> Hall_TIM_Pin_Start;
    ref = (u8) (temp & 0x07);
    return ref;
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

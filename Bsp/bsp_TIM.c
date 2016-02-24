/********************************************************************************
 *@FileName    bsp_TIM.c
 *@Author      Johnbee
 *@Version     V0.1
 *@Date        2015/10/19
 *@Brief       配置PWM输出   TIM1 CH1~CH3 PA8_PA10 为PWM输出 ABC三相
                             TIM1 CH1N~CH3N PB13_PB15 为PWM反向输出
 *******************************************************************************/
/*#includes*********************************************************************/
#include "bsp_TIM.h"

/*#define***********************************************************************/
#ifdef _STM32F10x_
#define TIM1_PWM_Frequence	36000  //PWM频率
#define TIM1_PWM_Period     2000  //PWM一个周期数
#endif
#ifdef  _STM32F4xx_
    #define _UES_TIM1_HALL_  //Enable the hall's interface of timer1
    #define TIM1_PWM_Frequence	(30000u)  //PWM频率30KHz
    #define TIM1_PWM_Period     (5600u)  //PWM一个周期数
#endif


/*
 *@ <function name=>TIM1_TRG_COM_NVIC_Config() </function>
 *@ <summary>
       TIM1 COM事件中断优先级配置
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void TIM1_TRG_COM_NVIC_Config(u8 preemPriority, u8 subPriority)
{
    NVIC_InitTypeDef NVIC_InitStructure;
    NVIC_InitStructure.NVIC_IRQChannel = TIM1_TRG_COM_TIM11_IRQn;// TIM1_TRG_COM_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = preemPriority;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = subPriority;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);
}
/*
 *@ <function name=>BLE_IRQPandler() </function>
 *@ <summary>
     This function handles motor timer trigger and commutation interrupts
     can be used for calculation...
     在stm32f10x_it.c中调用了
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void TIM1_TRG_COM_IRQPandler(void)
{
    TIM_ClearITPendingBit(TIM1, TIM_IT_COM);
    // commutationCount++;
}

/*
 *@ <function name=>TIM1_PWM_Config() </function>
 *@ <summary>
       配置定时器互补PWM输出
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
void TIM1_PWM_Config(void)
{
    TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
    TIM_OCInitTypeDef        TIM_OCInitStructure;
    TIM_BDTRInitTypeDef      TIM_BDTRInitStructure;
#ifdef _STM32F4xx_
    #if 1
        TIM1_GPIO_Config();
        RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM1, ENABLE);
        TIM_DeInit(TIM1);
        TIM_TimeBaseStructure.TIM_Period = TIM1_PWM_Period - 1;//周期
        TIM_TimeBaseStructure.TIM_Prescaler = SystemCoreClock/TIM1_PWM_Period/TIM1_PWM_Frequence - 1; //主频分频给定时器,输出频率
        TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;  //定时器分频
        TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up; //向上计数模式
        TIM_TimeBaseStructure.TIM_RepetitionCounter = 0;
        TIM_TimeBaseInit(TIM1, &TIM_TimeBaseStructure);

        /* Channel 1, 2,3 and 4 Configuration in PWM mode */
        TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM1;
        TIM_OCInitStructure.TIM_Pulse = 0;  //占空比
        TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_High;//输出极性设置
        TIM_OCInitStructure.TIM_OCIdleState = TIM_OCIdleState_Reset;//空闲状态时正向通道死区之后输出电平
        TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;//正向输出使能
        TIM_OCInitStructure.TIM_OCNPolarity = TIM_OCNPolarity_High;//互补通道输出极性设置
        TIM_OCInitStructure.TIM_OCNIdleState = TIM_OCNIdleState_Reset;//互补通道空闲状态时反向通道死区之后输出电平
        TIM_OCInitStructure.TIM_OutputNState = TIM_OutputNState_Enable;//互补通道输出使能

        TIM_OC1Init(TIM1, &TIM_OCInitStructure);					//使能TIM1_Channel2
        TIM_OC1PreloadConfig(TIM1, TIM_OCPreload_Enable);
        TIM_OC2Init(TIM1, &TIM_OCInitStructure);
        TIM_OC2PreloadConfig(TIM1, TIM_OCPreload_Enable);  //使能输出比较
        TIM_OC3Init(TIM1, &TIM_OCInitStructure);					//使能TIM1_Channel3
        TIM_OC3PreloadConfig(TIM1, TIM_OCPreload_Enable);         //
        /* DeadTime value n=1 bis 31: from 14ns to 1,7us
          DeadTime value n=129 bis 159: from 1,7祍 to 3,5ms
          DeadTime value 7 => 98ns
           ... see programmers reference manual
           DeadTime[ns] = value * (1/SystemCoreFreq) (on 72MHz: 7 is 98ns)*/
        TIM_BDTRInitStructure.TIM_DeadTime = 400;  //400对应死区时间2us大概
        /* Automatic Output enable, Break, dead time and lock configuration*/
        TIM_BDTRInitStructure.TIM_AutomaticOutput = TIM_AutomaticOutput_Enable;//AOE使能
        TIM_BDTRInitStructure.TIM_OSSRState  = TIM_OSSRState_Disable;  //Run状态定时器不工作时的输出
        TIM_BDTRInitStructure.TIM_OSSIState  = TIM_OSSIState_Disable;  //Stop状态定时器不工作时的输出
        TIM_BDTRInitStructure.TIM_LOCKLevel  = TIM_LOCKLevel_OFF;  //死区时间允许随时修改
        /* enabel this if you use emergency stop signal*/
    //    TIM_BDTRInitStructure.TIM_Break = TIM_Break_Enable; //刹车使能
    //    TIM_BDTRInitStructure.TIM_BreakPolarity = TIM_BreakPolarity_High; //刹车高电平有效
        TIM_BDTRInitStructure.TIM_Break = TIM_Break_Disable;
        TIM_BDTRConfig(TIM1, &TIM_BDTRInitStructure);
    //    TIM1->BDTR |= (1<<15);  //使能MOE位
        #ifdef  _UES_TIM1_HALL_
            // preload ARR register
            TIM_CCPreloadControl(TIM1, ENABLE);
            TIM_SelectCOM(TIM1, ENABLE);
            Hall_TimerConfig();
            // Choose carefully from the following possible combination
            // check programmers reference manual
            // TIM_SelectInputTrigger(TIM1, TIM_TS_ITR0);// MotorTimer = TIM1, HallTimer = TIM5
            // TIM_SelectInputTrigger(TIM1, TIM_TS_ITR1);// MotorTimer = TIM1, HallTimer = TIM2
            TIM_SelectInputTrigger(TIM1, TIM_TS_ITR2);// MotorTimer = TIM1, HallTimer = TIM3
            // TIM_SelectInputTrigger(TIM1, TIM_TS_ITR3);// MotorTimer = TIM1, HallTimer = TIM4
            // TIM_SelectInputTrigger(TIM8, TIM_TS_ITR0);// MotorTimer = TIM8, HallTimer = TIM1
            // TIM_SelectInputTrigger(TIM8, TIM_TS_ITR1);// MotorTimer = TIM8, HallTimer = TIM2
            // TIM_SelectInputTrigger(TIM8, TIM_TS_ITR2);// MotorTimer = TIM8, HallTimer = TIM4
            // TIM_SelectInputTrigger(TIM8, TIM_TS_ITR3);// MotorTimer = TIM8, HallTimer = TIM5
        #endif
        TIM_ARRPreloadConfig(TIM1, ENABLE);   //使能定时器重装载
        TIM_Cmd(TIM1, ENABLE);   //使能定时器1
        TIM_CtrlPWMOutputs(TIM1, ENABLE); //高级定时器才要加这一句
    #endif
#endif
    TIM1_Set_PWMOutput_EnableState(1, 1, 1);
    TIM1_Set_PWMOutput_EnableState(2, 1, 1);
    TIM1_Set_PWMOutput_EnableState(3, 1, 1);
    TIM1_Set_PWMDuty(1, 50);
    TIM1_Set_PWMDuty(2, 50);
    TIM1_Set_PWMDuty(3, 50);
}


/*
 *@ <function name=>TIM1_PWM_DutyChange() </function>
 *@ <summary>
     TIM1通道PWM波占空比调节
 *@ </summary>
 *@ <param name="myChannel">PWM通道1~4</param>
 *@ <param name="myDuty">占空比,0~1000</param>
 *@ <returns> null </returns>
 */
void TIM1_Set_PWMDuty(u8 myChannel, float myDuty)
{
    u16 tim1_perikd = TIM1_PWM_Period;
    u16 pulse = 0;
    if (myDuty < 0)
    {
        myDuty = 0;
    }
    else if (myDuty > 1000)
    {
        myDuty = 1000;
    }
    pulse = (u16)(tim1_perikd * myDuty / 1000);
    switch (myChannel)
    {
        case 1:
            TIM_SetCompare1(TIM1, (u16)pulse);
            break;
        case 2:
            TIM_SetCompare2(TIM1, (u16)pulse);
            break;
        case 3:
            TIM_SetCompare3(TIM1, (u16)pulse);
            break;
        case 4:
            TIM_SetCompare4(TIM1, (u16)pulse);
            break;
    }
}
/*
 *@ <function name=>TIM1_Set_PWMOutput_EnableState() </function>
 *@ <summary>
     同时设置PWM正反通道的输出使能,当OSSR和OSSI为同时为Disable时
     可同时失能正反通道达到正反通道同时输出为0的作用
 *@ </summary>
 *@ <param name="myChannel">PWM通道1~3</param>
 *@ <param name="pState">正向使能标志,0为失能,!0为使能</param>
 *@ <param name="nState">正向使能标志,0为失能,!0为使能</param>
 *@ <returns> null </returns>
 */
void TIM1_Set_PWMOutput_EnableState(u8 myChannel, u8 pState, u8 nState)
{
    u16 tim1_ccxp_state = TIM_CCx_Disable;
    u16 tim1_ccxn_state = TIM_CCxN_Disable;
    u16 tim_channel = TIM_Channel_1;
    if (pState)
    {
        tim1_ccxp_state = TIM_CCx_Enable;
    }
    if (nState)
    {
        tim1_ccxn_state = TIM_CCxN_Enable;
    }
    if (myChannel == 1)
    {
        tim_channel = TIM_Channel_1;
    }
    else if (myChannel == 2)
    {
        tim_channel = TIM_Channel_2;
    }
    else if (myChannel == 3)
    {
        tim_channel = TIM_Channel_3;
    }
    else
    {
        return;
    }
    TIM_CCxCmd(TIM1, tim_channel, tim1_ccxp_state);
    TIM_CCxNCmd(TIM1, tim_channel, tim1_ccxn_state);
}

/*
 *@ <function name=>TIM1_GPIO_Config() </function>
 *@ <summary>
       配置定时器PWM输出引脚
 *@ </summary>
 *@ <param name="void">null</param>
 *@ <returns> null </returns>
 */
static void TIM1_GPIO_Config(void)
{
    GPIO_InitTypeDef GPIO_InitStructure;
#ifdef _STM32F4xx_
    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA | RCC_AHB1Periph_GPIOB, ENABLE); //开时钟
    #if 1
        //电机TIM1PWM输出=PA8:PA10
        GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_9 | GPIO_Pin_10;
        GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
        GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
        GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
        GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
        GPIO_Init(GPIOA, &GPIO_InitStructure);
        GPIO_InitStructure.GPIO_Pin = GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15;
        GPIO_Init(GPIOB, &GPIO_InitStructure);
        GPIO_PinAFConfig(GPIOA, GPIO_PinSource8, GPIO_AF_TIM1); //启用定时器1复用功能
        GPIO_PinAFConfig(GPIOA, GPIO_PinSource9, GPIO_AF_TIM1); //启用定时器1复用功能
        GPIO_PinAFConfig(GPIOA, GPIO_PinSource10, GPIO_AF_TIM1); //启用定时器1复用功能
        GPIO_PinAFConfig(GPIOB, GPIO_PinSource13, GPIO_AF_TIM1); //启用定时器1复用功能
        GPIO_PinAFConfig(GPIOB, GPIO_PinSource14, GPIO_AF_TIM1); //启用定时器1复用功能
        GPIO_PinAFConfig(GPIOB, GPIO_PinSource15, GPIO_AF_TIM1); //启用定时器1复用功能
    #endif
#endif
#ifdef _STM32F10x_
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA | RCC_APB2Periph_GPIOB, ENABLE); //开时钟
    //电机TIM1PWM输出=PA8:PA10
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_9 | GPIO_Pin_10;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(GPIOA, &GPIO_InitStructure);
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15;
    GPIO_Init(GPIOB, &GPIO_InitStructure);
#endif
}
/****************** end of this file ********************************************


                                                             Copyright @JohnBee */

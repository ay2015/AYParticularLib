using System;

public class AyTime
{
    /// <summary>
    ///  2015年12月10日14:18:09 
    /// ay编写，用于方便定时任务，这里假如3000，那么第3秒执行
    /// </summary>
    /// <param name="millsecond"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static System.Windows.Threading.DispatcherTimer setInterval(int millsecond, Action action)
    {
        System.Windows.Threading.DispatcherTimer dTimer = new System.Windows.Threading.DispatcherTimer();
        //注：此处 Tick 为 dTimer 对象的事件（ 超过计时器间隔时发生）
        dTimer.Tick += (sender, e) => { action(); };
        dTimer.Interval = new TimeSpan(0, 0, 0, 0, millsecond);
        //启动 DispatcherTimer对象dTime。
        dTimer.Start();
        return dTimer;
    }

    public static System.Windows.Threading.DispatcherTimer setTimeout(int millsecond, Action action)
    {
        System.Windows.Threading.DispatcherTimer dTimer = new System.Windows.Threading.DispatcherTimer();
        //注：此处 Tick 为 dTimer 对象的事件（ 超过计时器间隔时发生）
        dTimer.Tick += (sender, e) =>
        {
            action();
            System.Windows.Threading.DispatcherTimer ds = sender as System.Windows.Threading.DispatcherTimer;
            if (ds != null)
            {
                ds.Stop();
                ds = null;
            }
        };
        dTimer.Interval = new TimeSpan(0, 0, 0, 0, millsecond);
        //启动 DispatcherTimer对象dTime。
        dTimer.Start();
        return dTimer;
    }
}

/// <summary>
/// 作用：用于创建指定执行次数的时间计时器，对AyTime的拓展，用于当前执行次数不能static，防止共享导致错误，特地创建一个AyTimeEx的类，用于每个重复执行任务，都有1个当前的执行次数
/// 时间：2016-6-20 00:09:57
/// 作者：AY
/// </summary>
public class AyTimeEx
{
    private int executeCnt = 1;
    private Action executeAction;
    private int millsecond;
    public System.Windows.Threading.DispatcherTimer currentDispatcherTimer;

    [ThreadStatic]
    int currentExecuteCnt = 0;

    public AyTimeEx(int _millsecond, Action _executeAction, int _executeCnt)
    {
        this.millsecond = _millsecond;
        this.executeCnt = _executeCnt;
        this.executeAction = _executeAction;
    }
    public void Start()
    {
        currentDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        currentDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, millsecond);
        //注：此处 Tick 为 dTimer 对象的事件（ 超过计时器间隔时发生）
        currentDispatcherTimer.Tick += (sender, e) =>
        {
            if (currentExecuteCnt >= executeCnt)
            {
                System.Windows.Threading.DispatcherTimer ds = sender as System.Windows.Threading.DispatcherTimer;
                if (ds != null)
                {
                    ds.Stop();
                    ds = null;
                    currentExecuteCnt = 0;
                }
            }
            executeAction();
            currentExecuteCnt++;
        };
        currentDispatcherTimer.Start();
    }

}



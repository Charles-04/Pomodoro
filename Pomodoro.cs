namespace Pomodoro
{
    internal class Pomodoro
    {


        private int _workDuration;
        private int _restDuration;

      

        private List<string> _workStartLogs = new();
        private List<string> _workStopLogs = new();
        private List<string> _restStartLogs = new();
        private List<string> _restStopLogs = new();


        public void PomodoroRule()
        {
            Console.WriteLine("Enter Work Duration In Minutes");
            var workDurationInput = Console.ReadLine();

            Console.WriteLine("Enter Rest Duration In Minutes");
            var restDurationInput = Console.ReadLine();

            Pomodoro pomodoro = new();

            try
            {
                pomodoro._restDuration = int.Parse(restDurationInput);
               pomodoro._workDuration = int.Parse(workDurationInput);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input Format");
                this.RestartPomodoro();
            }



                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;

                var workTime = new DateTime(2000, 1, 1, 0, pomodoro._workDuration, 0);
                var restTime = new DateTime(2000, 1, 1, 0, pomodoro._restDuration, 0);


                void WorkPomodoro()
                {

                    DateTime WorkStartTime = DateTime.Now;
                    string workStart = Convert.ToString(WorkStartTime);
                    _workStartLogs.Add($"Started working at : {workStart}");
                    Console.CursorVisible = false;
                    for (int i = 0; i <= pomodoro._workDuration * (int)Enums.CommonNumbersEnum.sixtySecs; i++)
                    {
                        Console.Write("Work Time Remains : {0}", workTime.ToString("mm:ss"));
                        workTime = workTime.AddSeconds(-1);
                        Thread.Sleep((int)Enums.CommonNumbersEnum.countDownTime);
                        Console.Clear();
                    }

                    DateTime WorkStopTime = DateTime.Now;
                    string workStop = Convert.ToString(WorkStopTime);
                    _workStopLogs.Add($"Stopped working at : {workStop}");

                    Console.Beep((int)Enums.CommonNumbersEnum.frequency, (int)Enums.CommonNumbersEnum.delayTime);
                    Console.WriteLine("Work Time Over");
                    Console.WriteLine("Rest Time Starts");

                    Thread.Sleep((int)Enums.CommonNumbersEnum.delayTime);
                    Console.Clear();
                }
                WorkPomodoro();
                void RestPomodoro()
                {
                    DateTime RestStartTime = DateTime.Now;
                    string restStart = Convert.ToString(RestStartTime);
                    _restStartLogs.Add($"Started resting at : {restStart}");

                    Console.CursorVisible = false;
                    for (int i = 0; i <= pomodoro._restDuration * (int)Enums.CommonNumbersEnum.sixtySecs; i++)
                    {
                        Console.Write("Rest Time Remains : {0}", restTime.ToString("mm:ss"));
                        restTime = restTime.AddSeconds(-1);
                        Thread.Sleep((int)Enums.CommonNumbersEnum.countDownTime);
                        Console.Clear();
                    }

                    Console.Beep((int)Enums.CommonNumbersEnum.frequency, (int)Enums.CommonNumbersEnum.delayTime);
                    DateTime RestStopTime = DateTime.Now;
                    string restStop = Convert.ToString(RestStopTime);
                    _restStopLogs.Add($"Stopped resting at : {restStop}");


                    Console.WriteLine("Rest Time Over");
                    Console.WriteLine("Press Y to continue or any other key to exit");

                    var Option = Console.ReadLine().ToUpper();

                    if (Option == "Y")
                    {
                        RestartPomodoro();
                    }
                    else
                    {

                        return;
                    }


                }

                RestPomodoro();



                DisplayLogs();
            
            


             
        }
      
        private void DisplayLogs()

        {
            
            for (int i = 0; i < _workStartLogs.Count; i++)
            {

                Console.WriteLine($"{i} : {_workStartLogs[i]} ");
                Console.WriteLine($"{i} : {_workStopLogs[i]} ");
                Console.WriteLine($"{i} : {_restStartLogs[i]} ");
                Console.WriteLine($"{i} : {_restStopLogs[i]} ");
            }
            
        }
        

        private void RestartPomodoro() => PomodoroRule();
        

        
    }
}

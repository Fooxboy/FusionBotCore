using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Fooxboy.FusionBot
{
    /// <summary>
    /// Работа с ядром
    /// </summary>
    public class Fusion
    {
        public event Delegates.NewMessage NewMessageEvent;
        IGetUpdates updater;
        public Fusion(IGetUpdates upd, IFusionCommand notCommand, IFusionSendMessage sendMessage, bool fullLog = true, bool logJson = false)
        {
            Log.War("Foooxboy.FusionBot Core. 2019. Version: 1.2");

            Log.Wr("Инициализация класса Fusion...");
            updater = upd;
            Globals.Message = sendMessage;
            Globals.NotCommand = notCommand;
            Globals.Log = fullLog;
            Globals.LogJson = logJson;
        }

        /// <summary>
        /// Остановка работы бота. Обнуление всех переменных.
        /// </summary>
        public void Stop()
        {
            updater.Stop();
            Globals.Message = null;
            Globals.NotCommand = null;
            Globals.Log = false;
            Globals.Commands = null;
            updater = null;
            Globals.TokenGroup = null;
            Log.War("Обнуления завершены.");
            System.GC.Collect();
        }

        /// <summary>
        /// Установка команды.
        /// </summary>
        /// <param name="command">экземпляр команды</param>
        [Obsolete("Метод устарел, используйте SetCommands. Использовать в случае добавления динамически новой команды.")]
        public void SetCommand(IFusionCommand command)
        {
            if (Globals.Commands is null) Globals.Commands = new List<IFusionCommand>();
            Globals.Commands.Add(command);
        }

        /// <summary>
        /// Установка массива команд
        /// </summary>
        /// <param name="commands">Массив экземпляров команды</param>
        public void SetCommands(params IFusionCommand[] commands)
        {
            Log.Wr("Инициализация массива комманд");
            if (Globals.Commands != null) throw new ArgumentException("Список команд не пуст. Добавте сразу все команды. Или используйте SetCommand");
            else Globals.Commands = commands.ToList();

            foreach(var command in commands)
            {
                Log.Wr($"Инициализация команды: {command.Command}" );
            }
        }

        
        /// <summary>
        /// Начало работы с Ядром бота
        /// </summary>
        /// <param name="token">Токен сообщества</param>
        /// <param name="groupId">Индентификатор группы</param>
        /// <returns></returns>
        public bool Start(object token, long groupId)
        {
            Log.Wr($"Запуск ядра Fusion...");
            Globals.TokenGroup = (string)token;
            updater.MessageNewEvent += NewMessage;
            Task.Run(() => updater.Start(token, groupId));
            Log.Wr("Инициализация ядра Fusion завершена");
            return true;
            
        }


        private void NewMessage(Models.MessageVK message)
        {
            try
            {
                Log.Wr($"Получено новое сообщение: {message.Text} от {message.PeerId}");
                NewMessageEvent?.Invoke(message);
                Processor.StartProcessor(message);
            }catch(Exception e)
            {
                Log.Error("произошла ошибка при обработке события NewMessage");
                Log.Error(e);
            }
            
        }
    }
}

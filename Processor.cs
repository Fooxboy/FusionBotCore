using System;
using Fooxboy.FusionBot.Models;
using Fooxboy.FusionBot.Models.Response;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Fooxboy.FusionBot
{
    public static partial class Processor
    {
        public static IFusionCommand FindCommand(string command)
        {
            Log.Wr("Поиск необходимой команды...");
            return Globals.Commands.Find(c => c.Command.ToLower() == command.ToLower());
        }

        public static void StartProcessor(MessageVK message)
        {
            Log.Wr($"Старт обрабоки сообщения: {message.Text} от {message.PeerId}");
            var actionText = String.Empty;
            if (message.PayloadString == null) actionText = message.Text.Split(' ')[0];
            else
            {
                message.Payload = JsonConvert.DeserializeObject<PayLoadModelFusion>(message.PayloadString);
                actionText = message.Payload.Command;
            }

            var command = FindCommand(actionText);
            if (command is null) command = Globals.NotCommand;
            Log.Wr("Старт нового потока выполнения команды...");
            Task.Run(() => ExecuteCommandRelease(command, message));
        }

        public static void ExecuteCommandRelease(IFusionCommand command, MessageVK msg)
        {
            try
            {
                Log.Wr("Начало выполнения команды.");
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                Log.Wr("Получение типа ответа команды");

                if (command.TypeResponse == TypeResponse.Text)
                {
                    Log.Wr("Тип команды - Текст");
                    Log.War($"Выполнение команды {command.Command}");
                    var result = command.Execute(msg) as String;
                    Globals.Message.SendText(result, msg.PeerId);
                    Log.Wr($"Отправление сообщения с тектом:{result} завершена.");
                }
                else if (command.TypeResponse == TypeResponse.TextAndButtons)
                {
                    Log.Wr("Тип команды - Текст и Клавиатура");
                    Log.War($"Выполнение команды {command.Command}");
                    var result = command.Execute(msg) as TextAndButtons;
                    Globals.Message.SendText(result.Text, msg.FromId, result.Keyboard);
                    Log.Wr($"Отправление сообщения с тектом:{result.Text} завершена.");
                }
                else if (command.TypeResponse == TypeResponse.PhotoAndButtons)
                {
                    Log.Wr("Тип команды - Фото и Клавиатура");
                    Log.War($"Выполенение команды {command.Command}");
                    var result = command.Execute(msg) as PhotoAndButtons;
                    Globals.Message.SendImage(result.Photo, msg.PeerId, result.Keyboard);
                    Log.Wr($"Отправление сообщения завершена.");

                }
                else if (command.TypeResponse == TypeResponse.TextAndPhotoAndButtions)
                {
                    Log.Wr($"Начало выполнения команды {command.Command}");
                    var result = command.Execute(msg) as TextAndPhotoAndButtons;
                    Globals.Message.SendImageAndText(result.Photo, result.Text, msg.PeerId, result.Keyboard);
                }
                else if (command.TypeResponse == TypeResponse.Photo)
                {
                    //TODO: отправка фотографии
                }
                else if (command.TypeResponse == TypeResponse.TextAndPhoto)
                {
                    //TODO: отправка фотографии с текстом.
                }
                else
                {
                    Log.Error("Команда имеет неизвестный тип ответа");
                }
                sw.Stop();
                Log.Wr("Конец обработки команды");
                Log.Wr($"Команда {command.Command} выполнялась {sw.ElapsedMilliseconds} ms");
            }catch(Exception e)
            {
                Log.Error($"Возникла ошибка при выполнении команды {command.Command}");
                Log.Error(e);
                Globals.Message.SendText($"Возникла ошибка при выполнении команды {command.Command}: {e}", msg.FromId);
            }
            
        }
    }
}

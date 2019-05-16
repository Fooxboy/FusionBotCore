using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.FusionBot
{
    public interface IGetUpdates
    {
        /// <summary>
        /// Начало получение обновлений
        /// </summary>
        /// <param name="token">Токен от сообщества ВКонтакте</param>
        /// <param name="GroupId">Индентификатор сообщества ВКонтакте</param>
        void Start(object token, long GroupId);
        /// <summary>
        /// Остановить получение обновлений
        /// </summary>
        void Stop();

        /// <summary>
        /// Новое сообщение
        /// </summary>
        event Delegates.NewMessage MessageNewEvent;
        /// <summary>
        /// Новый ответ
        /// </summary>
        event Delegates.NewMessage MessageReplyEvent;
        /// <summary>
        /// Изменение сообщения
        /// </summary>
        event Delegates.NewMessage MessageEditEvent;
        /// <summary>
        /// Разрешить получение сообщений в лс
        /// </summary>
        event Delegates.MessageAllowOrDeny MessageAllowEvent;
        /// <summary>
        /// Запретить получение сообщений в лс
        /// </summary>
        event Delegates.MessageAllowOrDeny MessageDenyEvent;
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.FusionBot.Models
{
    public class MessageVK
    {
        /// <summary>
        /// Индентификатор сообщения
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>
        /// Время и дата
        /// </summary>
        [JsonProperty("date")]
        public long Date { get; set; }

        /// <summary>
        /// Индентификатор диалога
        /// </summary>
        [JsonProperty("peer_id")]
        public long PeerId { get; set; }
        /// <summary>
        /// Реф соурс
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }
        [JsonProperty("ref_source")]
        public string RefSource { get; set; }
        /// <summary>
        /// Индентификатор пользователя отправившего сообщение
        /// </summary>
        [JsonProperty("from_id")]
        public long FromId { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// RandomId (Только для исходящих сообщений)
        /// </summary>
        [JsonProperty("random_id")]
        public long RandomId { get; set; }
        /// <summary>
        /// Вложения
        /// </summary>
        [JsonProperty("attachments")]
        public List<AttachVK> Attachments { get; set; }
        /// <summary>
        /// Находится ли в избранном это сообщение или диалог?
        /// </summary>
        [JsonProperty("important")]
        public bool Important { get; set; }
        /// <summary>
        /// Payload String
        /// </summary>
        [JsonProperty("payload")]
        public string PayloadString { get; set; }
        /// <summary>
        /// Payload Model
        /// </summary>
        public PayLoadModelFusion Payload { get; set; }
        /// <summary>
        /// Пересланные сообщения
        /// </summary>
        [JsonProperty("fwd_messages")]
        public List<MessageVK> ForwardMessages { get; set; }
        /// <summary>
        /// Действие, только для бесед.
        /// </summary>
        [JsonProperty("action")]
        public ActionChatVK Action { get; set; }
    }
}

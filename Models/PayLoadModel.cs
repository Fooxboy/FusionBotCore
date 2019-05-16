using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.FusionBot.Models
{
    [Serializable]
    public class PayLoadModel
    {
        public PayLoadModelFusion Fusion { get; set; }
    }

    [Serializable]
    public class PayLoadModelFusion 
    {
        /// <summary>
        /// Список аргументов
        /// </summary>
        [JsonProperty("arguments")]
        public List<object> Arguments { get; set; }
        /// <summary>
        /// Команда
        /// </summary>
        [JsonProperty("command")]
        public string Command { get; set; }
    }
}

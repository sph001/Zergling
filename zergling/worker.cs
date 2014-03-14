using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zergling
{
    class worker
    {
        public static string OwnerID { get; set; }
        public static string WorkerName { get; set; }
        public static string WorkerKey { get; set; }
        //status: get current status of the client
        //|Alive: Client is up and is currently mining
        //|Idle: Client is up, but miner has not been started
        //|Dead: Client is down.
        public static string Status { get; set; }
        public static string TotalHashRate { get; set; }
        public static string TotalCards { get; set; }
        public static string Shares { get; set; }

        private static string _gpu1HR = "0";
        public static string GPU1HashRate {
            get { return _gpu1HR; }
            set { _gpu1HR = value; }
        }
        private static string _gpu2HR = "0";
        public static string GPU2HashRate
        {
            get { return _gpu2HR; }
            set { _gpu2HR = value; }
        }
        private static string _gpu3HR = "0";
        public static string GPU3HashRate
        {
            get { return _gpu3HR; }
            set { _gpu3HR = value; }
        }
        private static string _gpu4HR = "0";
        public static string GPU4HashRate
        {
            get { return _gpu4HR; }
            set { _gpu4HR = value; }
        }
        private static string _gpu5HR = "0";
        public static string GPU5HashRate
        {
            get { return _gpu5HR; }
            set { _gpu5HR = value; }
        }
        private static string _gpu6HR = "0";
        public static string GPU6HashRate
        {
            get { return _gpu6HR; }
            set { _gpu6HR = value; }
        }
        public static string GPU1Temp { get; set; }
        public static string GPU2Temp { get; set; }
        public static string GPU3Temp { get; set; }
        public static string GPU4Temp { get; set; }
        public static string GPU5Temp { get; set; }
        public static string GPU6Temp { get; set; }
        public static string PoolURL { get; set; }
        public static string PoolUsername { get; set; }
        public static string PoolPassword { get; set; }
        //AdditionalArgs: used to pass additional arguments to the miner 
        public static string AdditionalArgs { get; set; }
    }
}

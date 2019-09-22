using PusherClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretHitlerMobile.ViewModels
{
    static class PusherConnectionController
    {
        public static Pusher _pusher;

        public static Channel _privateChannel;

        public static Channel _publicChannel;

        public static Channel _presenceChannel;
    }
}

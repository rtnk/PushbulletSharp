﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PushbulletSharp.Tests
{
    [TestClass]
    public class SubscriptionTests : TestBase
    {
        /// <summary>
        /// Pushbullets the get subscriptions test.
        /// </summary>
        [TestMethod]
        public void PushbulletGetSubscriptionsTest()
        {
            try
            {
                var subscriptions = Client.CurrentUsersSubscriptions();
                Assert.IsNotNull(subscriptions);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the get active subscriptions test.
        /// </summary>
        [TestMethod]
        public void PushbulletGetActiveSubscriptionsTest()
        {
            try
            {
                var activeSubscriptions = Client.CurrentUsersSubscriptions(true);
                Assert.IsNotNull(activeSubscriptions);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the get channel information test.
        /// </summary>
        [TestMethod]
        public void PushbulletGetChannelInformationTest()
        {
            try
            {
                var channelInfo = Client.GetChannelInformation("PushbulletSharp");
                Assert.IsNotNull(channelInfo);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the subscribe to channel test.
        /// </summary>
        [TestMethod]
        public void PushbulletSubscribeToChannelTest()
        {
            try
            {
                var response = Client.SubscribeToChannel("pushbullet");
                Assert.IsNotNull(response);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the unsubscribe from channel test.
        /// </summary>
        [TestMethod]
        public void PushbulletUnsubscribeFromChannelTest()
        {
            try
            {
                var subscriptions = Client.CurrentUsersSubscriptions();
                var target = subscriptions.Subscriptions.Where(o => o.Channel.Tag == "pushbullet").FirstOrDefault();
                Assert.IsNotNull(target, "Could not find the target Channel");

                Assert.IsTrue(target.Active, "Target is not active. Cannot unsubscribe.");
                Client.UnsubscribeFromChannel(target.Iden);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

using Moq;

namespace BankOfGeorgia.IpayClient.Tests
{
    public class BankOfGeorgiaIpayClientTests_Relogin
    {
        //TODO:
        // Relogin

        public void MakeOrderAsync_SecondCallWithInvalidToken_ShouldReloginLogin()
        {
            //var httpClientMock = new Mock<HttpClient>();
            //httpClientMock
            //    .Setup(c => c.SendAsync(It.IsAny<HttpRequestMessage>()))
            //    .Returns(message => Task.FromResult(new HttpResponseMessage() { }));


            //TODO: 
        }

        public void MakeRecurringOrderAsync_SecondCallWithInvalidToken_ShouldReloginLogin()
        {
            //TODO: 
        }

        public void CompletePreAuthPaymentAsync_SecondCallWithInvalidToken_ShouldReloginLogin()
        {
            //TODO: 
        }

        public void RefundAsync_SecondCallWithInvalidToken_ShouldReloginLogin()
        {
            //TODO: 
        }

        public void GetPaymentDetailsAsync_SecondCallWithInvalidToken_ShouldReloginLogin()
        {
            //TODO: 
        }
    }
}

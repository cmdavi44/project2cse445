using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Order
    {
        private int senderID;
        private int cardNo;
        private int receiverID;
        private int quantity;
        private double unitPrice;
        private DateTime orderStartTime = DateTime.Now

        public Order(int senderID, int cardNo, int receiverID, int quantity, double unitPrice)
        {
            this.senderID = senderID;
            this.cardNo = cardNo;
            this.receiverID = receiverID;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }

        public int getSenderID()
        {
            return senderID;
        }

        public int getCardNo()
        {
            return cardNo;
        }

        public int getReceiverID()
        {
            return receiverID;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public double getUnitPrice()
        {
            return unitPrice;
        }

        public DayTime getStartTime()
        {
            return orderStartTime.ToString
        }
    }
}

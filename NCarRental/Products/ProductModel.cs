using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCarRental
{
    public class ProductModel : ObservableObject
    {
        #region Fields

        private int _productId;
        private string _productName;
        private int _productPrice;
        private int _productQuantity;
        private int _productEvjarat;

        private decimal _unitPrice;

        #endregion

        #region Properties

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value != _productId)
                {
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value != _productName)
                {
                    _productName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (value != _unitPrice)
                {
                    _unitPrice = value;
                    OnPropertyChanged("UnitPrice");
                }
            }
        }

        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductEvjarat { get; set; }

        #endregion
    }
}

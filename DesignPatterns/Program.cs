using DesignPatterns.StrategyPatterns.PaymentSystems;


CreditCardPayment creditCardPayment = new CreditCardPayment();
PaymentStrategy paymentStrategy = new PaymentStrategy(creditCardPayment);
paymentStrategy.ProcessPayment();
//change the payment strategy to banktransfer payment
paymentStrategy = new PaymentStrategy(new BankTransferPayment());
paymentStrategy.ProcessPayment();
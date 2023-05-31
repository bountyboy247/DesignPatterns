using DesignPatterns.StrategyPatterns.PaymentSystems;
using System.Diagnostics;

//Problem: Design a payment processing system for an e-commerce platform that supports
//multiple payment methods, such as credit cards, PayPal, and bank transfers.
//The system should be flexible enough to easily add new payment methods in the future.

//Requirements:

//The system should allow customers to select their preferred payment method during
//the checkout process.
//Each payment method should have its own implementation for processing payments.
//The system should be extensible, allowing the addition of new payment methods without modifying
//existing code.
//The system should handle any changes or updates to the payment methods without affecting the rest
//of the application.
//Design a solution using the Strategy design pattern to address the above problem. Describe the
//classes, interfaces, and relationships involved in your design, and explain how
//the Strategy pattern helps achieve the desired flexibility and extensibility.



CreditCardPayment creditCardPayment = new CreditCardPayment();
PaymentStrategy paymentStrategy = new PaymentStrategy(creditCardPayment);
paymentStrategy.ProcessPayment();
//change the payment strategy to banktransfer payment
paymentStrategy = new PaymentStrategy(new BankTransferPayment());
paymentStrategy.ProcessPayment();
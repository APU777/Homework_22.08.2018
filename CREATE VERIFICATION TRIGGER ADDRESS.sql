 CREATE TRIGGER Subscriber_VerificationAddress ON Subscribers FOR INSERT
 AS
 BEGIN
			INSERT Address_Subscribers
				(ID_SUBSCRIBER)
			SELECT 
				ID_SUBSCRIBER
			FROM INSERTED
 END
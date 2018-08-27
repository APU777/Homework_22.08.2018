 CREATE TRIGGER Subscriber_VerificationPhoneNumber ON Address_Subscribers FOR INSERT
 AS
 BEGIN
			INSERT Phone_Number
				(ID_SUBSCRIBER, ID_ADDRESS)
			SELECT
				ID_SUBSCRIBER,
				ID_ADDRESS
			FROM INSERTED
 END
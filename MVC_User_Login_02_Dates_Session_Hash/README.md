# MVC Login Application

### Author : Philip Anderson

### Date : August 2019

### Version : 1.00 

Version details

First 'sprint' of a login application.

Four pages : landing page, list of users, register new user, log in as a user.

Model : userid, username, password

All the basic functionality just works.

### Version 2.0

	This adds the following fields to the User class:

		isactive, createddate, modifieddate, modifiedby, createdby

	It uses datetime.utcnow as the date

	It ensures a user has a valid login session before continuing.

	If the password is invalid at registration or login then appropriate messages are given

	If the username is present then a message appears that this user already exists

	If the password is too short or long then a message appears (8-20 characters)

	If the password does not have one symbol then a message appears

	A session timeout of 1 minute exists.

	If we attempt to view users, if a valid session does not exist then the page redirects to the login page with an appropriate message.

	Users are created with IsActive,CreatedDate,ModifiedDate,CreatedBy and ModifiedBy fields.

	If fields are blank the user is notified.
	
## Future Versions

	Add delete

	Modify the user 

	Delete the user (make inactive)

	Read only inactive users

	Hash password with BCrypt

	
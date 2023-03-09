# MailTest

Practical Tasks

When performing a task, you must use the capabilities of Selenium WebDriver, 
a unit test framework (for example NUnit) and the Page Object concept.

Create two fake accounts on different email services.
Implement the following autotests:
 - Tests for login/password on one of the services (the ability to login with the correct login/password pair, 
 the impossibility of login with the wrong password and/or login, 
 the impossibility of login with empty login/password, etc.).
 - Log in to one of the services and send a letter from it to another mailbox of predefined randomly generated content. 
 Make sure that the letter has arrived and is displayed as unread and that it has the correct sender. 
 Read the letter and verify that the real content matches the sent one. 
 Send back a response to the first server containing the new user alias for the first mailbox.
 - Log in to the first mail server, and change his nickname to the new one in the user's personal data. 
 Verify that the nickname has changed.
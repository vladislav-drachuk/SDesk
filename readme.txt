-problem with swagger: methods of MailsController and AttachmentsController not show, because of versioned controllerMailsV2Controller;

-MailController.GetMails() (url http://localhost:61811/api/mails without "api-version: 2" in header) 
 and
 AttachmentsController.GetAttachments(int id, string extention = null, int status = 0)
(url http://localhost:61811/api/mails/1/attachments  without "api-version: 2" in header)
thowns exceptions;

-see logs of exception in Sdesk.API/logs/log.txt;

-see screens of xml and json responce in "screen" folder

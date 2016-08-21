# SendRight - send safe!

## Overview

Have you ever sent an email and accidentally added a wrong person to
the recipients list?

In the past, I have seen it happen to clients, suppliers, peers,
and, most regrettably, even to myself.

I created SendRight in order to have a fighting chance against the
rare-yet-potentially-hazardous Outlook auto-complete mistakes.

SendRight is an Outlook add-on (for Outlook 2013 and 2016) that gets
activated whenever you click the Send button to send an email.

Once you attempt to send an email, SendRight kicks in and reviews
the list of recipients. Then, by checking against several rules, it
decides whether a recipient was added in mistake - and if so - alerts
you with a friendly popup.

For example, one of the rules is: "alert when sending an email with a
recipient inside the company in the TO line, and one or more
recipients from OUTSIDE the company in CC". This makes sense because
in most internal emails there is no need to CC recipients from outside
the company, and if an external recipient is CCed - it might be a
personal contact, a supplier, or even a client that you don't want to
expose the internal communication to.

Once alerted, if you decide to go ahead and send the email anyway -
SendRight will automatically remember the list of recipients that you
approved and will not alert you again when sending to them.

In other words - SendRight will quickly learn your emailing habits and
eventually you will very rarely see "wrong" alerts.


## Privacy

SendRight relies only on the recipients list and does not look at the
content of your emails at all.

SendRight is open source and anyone is welcome to look at the code and
compile their own version for themselves or for their company.


## Usage

SendRight is useful right out of the box. It automatically deduces
your company domain by looking at your Outlook accounts and is ready
to protect you without further configuration.

However, it is possible to adjust the rules and do some other cool
stuff.

Open the Settings popup or disable SendRight (until Outlook is
restarted) from the SendRight ribbon:

![Ribbon](http://www.sendright.email/images/ribbon.png)


### First use

The first time you start Outlook after running the installer, the
SendRight settings window will pop up automatically:

![Settings - Welcome](http://http://www.sendright.email/images/settings/welcome.png)

Notice the checkbox at the bottom; if checked - SendRight will add
a short line of text to the end of every new email you create. You will
see this line when you edit the email and will be able to remove it.
This is a good way to let peers and other recipients know that you take
email privacy seriously and encourage others to do the same.


### Controlled Domains

A "Controlled Domain" is a domain that will be protected by SendRight.
Most users have a single Controlled Domain that is the domain of their
company. When one or more of the recipients email addresses are at a
Controlled Domain - SendRight will test the recipients list against the
rules and alert if necessary.

![Settings - Controlled Domains](http://http://www.sendright.email/images/settings/controlledDomains.png)

For example, if you configure "mycompany.com" as your Controlled Domain,
SendRight would alert if you send an email to "joe@mycompany.com" with
"jane@anothercompany.com" in the recipients list.

You can have any number of Controlled Domains, and each would be
reviewed separately; if you have two Controlled Domains: "mycompany.com"
and "myothercompany.com" - an email to recipients in both of those
domains would raise an alert.

It is possible to have a list of domains be considered as a single
domain by specifying them in the Controlled Domain(s) text box,
separated by a comma:

![Settings - Multiple Controlled Domains](http://http://www.sendright.email/images/settings/controlledDomains.multiple.png)

This is useful if your company has multiple domains. For example, if you 
set "mycompany.com" and "mycompany.biz" together, they will be treated
as synonyms and sending to recipients in both domain in the same email
will not raise an alert.

Suppose that you send an email to "joe@mycompany.com" and to
"jane@anothercompany.com":

![Email](http://http://www.sendright.email/images/email1.png)

When you try to send it, you will get this alert:

![Email](http://http://www.sendright.email/images/email1.risks.png)

If you click on SEND - the email will send, and an exception will be
added for the relevant Controlled Domains so that in the future, emails
sent to both "joe@mycompany.com" and "jane@anothercompany.com" will no
longer trigger an alert:

![Settings - Controlled Domains - Exception](http://http://www.sendright.email/images/settings/controlledDomains.exception.png)


### Rules

SendRight offers six different rules:

![Settings - Rules](http://http://www.sendright.email/images/settings/rules.png)

Each rule can be enabled or disabled and some of the rules have
parameters that can be adjusted:


#### Warn when emailing protected addresses

It is possible to pop up an alert whenever emailing a protected address.
This can prevent accidentally sending an email to a sensitive address
**inside** the company. A while back there was a story going around
about a CFO that accidentally emailed the company's salary sheet to
all@ address.


#### Warn when emailing move than N recipients

When emailing a lot of people it may be useful to receive an alert and
have a chance to reconsider whether they should all be in the
correspondence, or even just to just have another quick review of the
text.


#### Warn when emailing multiple addresses that are **not** in a Controlled Domain

This rule applies to all emails, regardless of the Controlled Domains
configuration. For example, it will alert when sending to
"joe@somecompany.com" and "jane@someothercompany.com". The idea is
that many emails are not meant for people not in the same company.
For example, when emailing a client and accidentally putting another
client in the CC.


#### Warn when there is a Controlled Domain in the TO line and one or more non-Controlled Domains in CC or BCC

This rule is similar to the previous one, but only takes effect when
there is an address at a Controlled Domain in the TO line.


#### Warn when the TO line has both Controlled Domains and non-Controlled Domains

Similar to the above rule, but pertains specifically to the TO line.


#### Warn when sending email from an address that is not in a list

You should put your own email address (or email addresses) in this
rule's text box. For example, it may be useful to be notified when
sending out of an addresses such as "support@mycompany.com" in case
it's being done in mistake (e.g. when replying internally to an email
received at the support mailbox)


### Statistics

SendRight collects simple statistics of how many emails it reviewed,
how many violated a rule, and how many times you decided to cancel the
send after receiving the alert.

![Settings - Statistics](http://http://www.sendright.email/images/settings/statistics.png)


### Export / Import

It's possible to export all of the settings (including all Controlled
Domains, all of the exceptions, all of the statistics, etc...) to a
file and then import them on another computer.

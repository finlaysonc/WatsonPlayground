This project uses IBM's Watson Analyzer to analyze the tone in two types of communications: communications with N particiipants, and communication by one participant. A Text message thread is an example of the former, whereas an email is an example of the latter. Watson analyzes sms message threads on a per sentence basis; there is no "overall" score for a text message thread.  Analysis of single speaker's communication can be done at the overall level and/or sentence levvel.  Watson has a default cut-off for a tone's score or else it won't return it; ana anlysis can result in zero or more tone results. An analysis of an email can have 0 to N tones as the overall analysis; optionally one can request a sentence analysis as well which will result in each sentence having 0 or more tones. Text message sentences also have zero or more tone results.  

The communication and results are stored in MSFFT's localdb instance using Entity Framework.  A table per hierarchy model with the conventional concrete base class model represents the messagee types: SMS Threads and general "content" such as email. A content message and SMS Thread have 0 to many "ToneScores" (even though currently Watson does not support an overall SMS Thread analysis just quite yet).  An SMS Thread has many SMS Messages; those individual sms messages have 0 to many ToneScores.

When run, this will delete database "SaraDev" if it exists on localdb, then create a new one seed it with meessages, and store the tone score results along with it. 
After storing the results, it prints the scores out.



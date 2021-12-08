# SceneAndPlayerWeek8

In this game we completed two assignments:

1) Scene and modeling:

* We created an office with furniture.
* Corridor which leads to the office.
* We added light to the office (with a switch to turn it on and off).
* We added a staircase that leads to our office from the main building.


2) Player - Interaction:

* We put a treasure chest inside the office, in order to open it PRESS E and in order to collect ("loot") the prize PRESS Z. (Need to stand next to the chest)
* We added a switch to the light, when you are standing close to it PRESS E to flip the switch on/off.
* We emplaced a NPC in the office, when you stand next to it - a message appears above him which instructs the player what to next and how. PRESS E to navigate between the messages.

תחילה נראה את המבנים שהוספנו לעולם של אראל:
ניתן לראות כי מה שמחבר בין המבנה שלנו למבנה של אראל הוא המסדרון ובנוסף המשדרון מחובר למבנים בעזרת מדרגות

![image](https://user-images.githubusercontent.com/73071299/145184092-aeb165e9-256f-4094-a557-d28eeaf74fd8.png)


מסדרון:

![image](https://user-images.githubusercontent.com/73071299/145184469-eb7f14ce-d957-462c-b963-06794bd862b9.png)

משרד:

![image](https://user-images.githubusercontent.com/73071299/145184676-efcafa04-4f34-4b46-8877-89625fa1a4ea.png)

כעת נעבור על המשימות שביצענו:

1) We put a treasure chest inside the office, in order to open it PRESS E and in order to collect ("loot") the prize PRESS Z. (Need to stand next to the chest)
 
לאחר שלחצנו E נפתח האוצר:

![image](https://user-images.githubusercontent.com/73071299/145185251-2bccb797-8e07-43de-8c15-d042081c35ef.png)


ולאחר שלחצנו Z אספנו את האוצר:

![image](https://user-images.githubusercontent.com/73071299/145185370-e6c3c7ad-7982-48f9-921f-03d7f5ca06ef.png)


כעת נסביר איך מימשנו זאת:

Script TreasureController:


בתחילת הscript נקבל מערך בגודל 3 של game object שכל  איבר במערך מסמל מצב שונה של התיבה:

![image](https://user-images.githubusercontent.com/73071299/145186021-3a55ef4e-afbe-499f-a9c1-cdb87af281e0.png)


לאחר מכן עשינו את תיבת האוצר כטריגר על מנת שהתיבה תשנה מצבים רק כשאנחנו ברדיוס מסיום ולא תשנה מצבים כאשר אנחנו רחוקים ממנה:

![image](https://user-images.githubusercontent.com/73071299/145186353-fa4fa983-0fb3-44f8-8728-0739d8d562b5.png)


ולבסוף אנו בודקים אם אנחנו מספיק קרובים והאם לחצנו על המקש הנדרש על מנת לעבור למצב הבא:

![image](https://user-images.githubusercontent.com/73071299/145186499-6b04eb40-e8fd-4360-8817-8d05cbe5f5fe.png)


2) We added a switch to the light, when you are standing close to it PRESS E to flip the switch on/off.
להלן המתג:

![image](https://user-images.githubusercontent.com/73071299/145186950-a644949c-7d97-4e28-9b11-5925ed1d10b4.png)
 
תחילה קיבלנו שלושה אובייקטים:
הראשון מייצג את המתג הדלוק-
השני מייצג את המתג הכבוי-
השלישי מייצג את האור-
כשאנו רק מאפסים את ה-script אנו מעבירים את המתג למצב on

![image](https://user-images.githubusercontent.com/73071299/145187197-a990d689-aacb-4361-91bb-b9fac398f487.png)

עשינו את המתג טריגר מכיוון שאנו רוצים רק כאשנחנו נהיה קרובים מספיק תנתן לנו האופציה להדליק את האור לכבותו:

![image](https://user-images.githubusercontent.com/73071299/145187598-edacc262-13d5-4659-a2cc-ed402d314867.png)


3) We emplaced a NPC in the office, when you stand next to it - a message appears above him which instructs the player what to next and how. PRESS E to navigate between the messages.

תחילה נקבל את כל ההודעות כמערך של אובייקטים ותמיד נבדוק האם אנו קרובים מספיק ל-npc.
אם אנו מספיק קרובים תפתח לנו ההודעה הראשונה ונוכל לתחיל לנווט בין ההודעות אחרת לא נראה את ההודעה הראשונה:

![image](https://user-images.githubusercontent.com/73071299/145188347-d4e7042f-6f22-4089-9392-b314b8c40162.png)
 
 כעת נראה כי אנו תמיד מדליקים הודעה אחת ומכבים את השנייה ומכייון שאנו משתמשים במודולו לעולם לא נחרוג מהמערך ולבסוף כשאנו,
 יוצאים מהטריגר אנחנו מכבים את ההודעה האחרונה:
 
 ![image](https://user-images.githubusercontent.com/73071299/145188564-0e20127b-97cf-425c-b4e8-2ea02b9a7bb9.png)







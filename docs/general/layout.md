---
title: Project Layout
weight: 0
---

# Project Layout

[This](../img/navigation/fullnavigation.png) is full navigation layout
### Home
[Home](../img/navigation/homeview.png) is linked to [Profile](../img/navigation/profileview.png),  [Chat](../img/navigation/chatroomview.png), [Cheer](../img/navigation/shopcheerview.png) --> [Items](../img/navigation/shopitemview.png) and [Settings](../img/navigation/settingsview.png) views through buttons.

Home page has 2 main stack view. First is contain webview, Second one is contain ui buttons. For better visualization about stack views check this [image](../img/layout/homelayout.png)
User has to be login both app and website login system otherwise streaming button will popup [Signin](../img/navigation/siginpopup.png) view.   
Users can register through website. 

### Profile

[Profile](../img/navigation/profileview.png) is linked to [Daily Tasks](../img/navigation/dailytasksview.png), [Signin](../img/navigation/siginview.png), [Exp Purchase](../img/navigation/expbuy.png) and [Cheer](../img/navigation/shopcheerview.png) through the buttons. 

This view divided 3 main stack [views](../img/layout/profilelayout.png). User level section has Login button link to Sigin view. All user informations are saved Firebase DB --> Users --> UUID (uniqe id generated by Firebase).

Reward Section contain only ui views.

Level up section is has 3 buttons and linked to exp card purchase view, daily tasks view and Cheer purchase view respectively.  

#### Daily Tasks

[Daily](../img/navigation/dailytasksview.png) is only linked to Profile view. Divided 3 main stack [views](../img/layout/dailytaskslayout.png).  User Info section;  most of datas are retrieve from Firebase database, only cheer data value retrieve from AWS database. Daily Login section; contain UI view and related functions. Daily Missions section; Information about mission and button for collecting reward, buttons are will active when user finised the task otherwise will be inactive. Active buttons color is orange, inactive buttons color is gray. Every task has different shop points and exp point.

### Chat Room

[Chat](../img//navigation/chatroomview.png) is linked to [Signin](../img/navigation/siginview.png) and [Home](../img/navigation/homeview.png) through to butttons in Top section [view](../img/layout/chatroomlayout.png). Chat section shows list of the message save in Firebase --> Msgs documents. Bottom section; image picker and emoji view list hidden under plus "+" button and send button will hidden until user type any text or select any image(or emoji).  Top section and Section backgrounds are synchronized with ui button style. 

### Cart

Shop Cart has simple stack [view](../img/layout/shopcartlayout.png) tab buttons and view sections view section. View section shows cheer purchase view (default view) and app item purchase view. The shop cart view is linked only to the home view. Other content shows as a subview using the Bottom Sheet plugin. The toolbar contains shop points and the total cheer the user has. 


#### Cheer Purchase

There are 7 [Cheer](../img/navigation/shopcheerview.png) purchase products available.  500, 1000, 3000, 5000, 10000, 30000, and 50000 products are listed in view. If the user not logged in it will shows a notification. After successfulll purchase it will shows a notification.   

#### App Items Purchase

There are 6 subview exist in App Item [View](../img/navigation/shopitemview.png). All subviews has 2 detents; medium and large.  Detents are dynamically adjusted the [subview](../img/layout/shopcartlayout.png) height. 

There are 3 purchase notification;

- [Not enough](../img/layout/notenough.png) Cheer or shopping Point
- [Already have](../img/layout/alreadyhave.png) item
- [Successfully](../img/layout/successfull.png) purchased 

these notification are implemented in all app item purchase system.  


##### Exp Purchase

Simple a stack [view](../img/layout/expbuylayout.png) with a purchase button. Detents set medium as default value. The maximum number of card purchases at a time has been determined as 99. 

##### Exp Multiply 

A [view](../img/layout/expmultiplylayout.png) contain 3 stack views. Stack view contain information text and button. On button click it will show a confirmation dialog. 

##### UI Style

There are 3 main stack [views](../img/layout/uiitems.gif). These are button styles(3 items), background images(6 items) and backround color(6 items). All items can be purchased either with Cheer or Point. On Items click will show purchase options dialog. Every item group prices are different, button styles are each 500 Cheer or 500 Point, background images are each 200 Cheer or Point and background colors are each 50 Cheer or Point. Button Styles are set with a uniqe background images and background images and background color can be used in chat room background settings.

##### Font Style

There are 2 main stack [views](../img/layout/fontstylelayout.png).  These are font colors (6 items) and font styles(4 items). All items can be purchased either with Cheer or Point. On Items click will show purchase options dialog. Every items can be purchase  50 Cheer or 50 Point. Font style and font color can effect chat message text style. 

Note: Currently font style not effect logographic kanjis and furigana

##### Emojis

There are 5 items using same view model within only stack [view](../img/layout/emojilayout.png) shows a list view.  
List items are clickable and show full list of the emoji group items. Items can be purhcase with cheer only and each emoji group is cost 500 cheer. On list clicked will show a [popover](../img/layout/emojilistlayout.png). 


##### Animated Emojis

There are 5 items using same view model within only stack [view](../img/layout/stickerlayout.png) shows a list view.  
List items are clickable and show full list of the emoji group items. Items can be purhcase with cheer only and each emoji group is cost 1000 cheer. On list clicked will show a [popover](../img/layout/stickerlistlayout.mp4). 

### Settings

[Settings](../img/navigation/settingsview.png) is connected Home and Item views. Settings is divided for 3 sections. 

1. General
2. Blocked User 
3. Others

General section currently contain only owned items. Can find more detals in Items (Navigate to Items).

Blocked Users has only list of the blocked users.

Others section has 3 settings one of them share the application. the other is a toogle for showing level log in chat room view. When user reach level 2 it will automaticly will turn on. And last one is delete the account; this settings is required to publish the application in App Store. Delete the account is requests the deletion of data from both Firebase and AWS databases. 


#### Items

Item Lists [Owned Items](../img/navigation/owneditemlist.png) connect to Settings view. Divided 4 section with section header. All datas are saved in Owned Items array of users Firebase data collection. All settings effects only app view and styles, there is no effect on Cheer Supports webview also chat items cannot be use in streaming chat.

1. Background; This is for chat room message area background design settings. Onclick shows a menu, if the user has any color or image will show the submenu as Color or Images, and other default and cancel options available in the menu view list. "Background" text is clickable. For better performace all Horizontal Stack view should be button. 

2. Button; This is change set style for home button ui view style and also chat room top bar and bottom bar ui view. If user has any style it will shows a menu option with name.

3. Font; There are 2 settings in this section font style and font color. Onclick shows a menu, if user has any font style or color will show the name in related menu. Current font styles are not effected furigana and kanjis. Need to add new styles for both Japanese and Chinese languages and Font Style Item view in shop should also changed based on language.

4. Chat Items; Currently we have emojis and animated emojis items can be used in the app chat system. It is a dropdown list and shows a list of chat items purchased as text. List items are non-clickable.

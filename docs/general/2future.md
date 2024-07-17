# Future of App

There are a couple of features that need to be added and some that need to be updated for better app quality. It will be divided into 2 sections New Features and Updates Required Features. Couldn't put the app in stress tests. Based on my testing some features consume too much RAM for example animated emojis in the empty chat consume an average 30 mb when adding images or animated emojis it will rise to 100 mb. By following SDWebImageSwiftUI documentation instructions for cache managing decrease ram usage to 70 mb. Need additional measurements to further decrease for better performance. Some features need to be added (some of them are requested from the client). 

### Updates Required Features

All of these suggestions are for better user experience and better app performance.  Feel free to implement solutions If you notice different issue(s) or have better solutions. Overall we are developers, and building the best products is our first task.

-  Webview is loading slowly. Excluding external reasons (non-app related reasons like wireless connection speed, connection signal quality, mobile phone CPU speed, RAM capacity of the phone, IOS version, etc.) there are multiple solutions to improve app quality. 
    1. Webview app speed is directly linked to website performance. Therefore improve website load speed.
    2. By decreasing task requests before the app launch.
    3. Better user experiences add a loading image or some images can hide the loading process. Hide the image when webview is fully loaded.

-  Animated Emojis consume too much RAM therefore certain views need attention. Global Chat, ShopView/Animated Emojis view are currently using SDWebImageSwiftui. 
    1. Show limited messages in history of the messages.
    2. Play once or twice animated images. 
    3. On tap gesture play selected emojis animation.
    4. Stop playing all animated emojis when the user saw the list.  

- Change the Full design of Shop Cart View. The current Bottom Sheet plugin response is not good enough.
    1. Change the bottom sheet view system to a navigation link system.
    2. Native sheet detents (medium and large) options are available IOS version 16.0 or later. Either change the minimum target version from 15.1 to 16.0 to create a dynamic detents system.  
    
- Add more emojis.

- Add more animated emojis.

- Add more UI styles. Current font styles are working on romaji letters, add more font styles, especially for furigana and kanji. 

- Update settings UI view with better design.

- Replace the webview system with an application-specific system with new ui design and with synchronized current website database.



### New Features

 Before explaining new features there are a few points that need to mention. Before started developing the mobile application there was a conversation about changing Cheer Support web content. At first idea was a full renewal of the web content and then middle of development it is changed to re-design. Those are 2 different approaches. Because of the uncertainty mobile app structure becomes more restricted.
 
 Renewal is changing all structures, API routes, UI design, and database of the web content. Anything related back-end will directly affect the mobile application.  
 
 Redesigning, on the other hand, affects the user's view of web content. While this approach has a potential impact on the backend, it will be limited and, therefore on impact the mobile app also limited. 

 Members who could work were limited. I worked with only one graphic designer on this project. He creates most of the images, emojis and animated emojis, the rest is done solely by me. There was only one front-end developer in the web content, but she was working as a full-stack developer. So working with her also was out of the option.

 There were requests from the CEO and client. Most of them are already done and there are 2 features left to implement for finishing the app. There are preparations to be made before adding these features, as well as the completion of the redesign of the website and the completion of the back-end related new design.

 - At the time of writing this document, there were 7 WebGL applications in the web content. All WebGL applications are developed with a cross-platform called [Unity Game Engine](https://unity.com/). These applications do not work on mobile browsers and the CEO requested that these applications be available on mobile devices. To achieve this those are the preparations required;
    
    1. Convert to WebGL application to IOS application
    2. Optimized the app for mobile (for example occlusion culling, lightmap, decrease the RAM usage ...)
    3. Add UI and controller system for mobile app use
    4. Decrease the size of the app (There is a maximum size limit to upload the App Store)

 The above steps should be followed for 6 applications. WebGL applications called Hoshiyomi are already published on the App Store and Play Store.

 - Add the Augmented Reality future with body and face tracking to the live-streaming feature. 

 - Add noice cancelling feature to live-streaming.



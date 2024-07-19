---
title: Introduction
weight: 0
---

# Introduction

1. This application developed on IOS 15.1 - 17.4 - using Swift / Objective-C - with SwiftUI framework

2. This applicaiton is intended for use smartphone only, in a portrait orientation.

3. JSON requests are used to handle the communication between the app and servers.

4. This application works only in online mode.

5. Push notifications are handled by Firebase.

6. Real-time messages are handled by Firebase.

7. User Daily Login informations are handled by Firebase, all information mobile application usage related only.

8. New User registration can be done webview only. 

9. Webview datas are handled by AWS

10. In app purchase system is implemented the mobile application only


### Purpose
This document provides a technical guide for iOS developers involved in the development, implementation, and maintenance of an iOS app.

### Audience
- iOS Developers
- Project Managers

## 2. System Overview

### Technology Stack
- **iOS SDK**: Development platform for building native iOS applications.
- **Swift Programming Language**: Primary language used for iOS app development.
- **Firebase**: Backend-as-a-Service platform for authentication, database (Firestore), and cloud functions.

### Architecture Overview

The app follows the Model-View-ViewModel (MVVM) design pattern:

- **Model**: Data models for user profiles, login records. The Model in MVVM represents the data and business logic of the application. It is responsible for retrieving data, processing it, and defining how the data can be changed and manipulated.

- **View**: Interface elements designed using SwiftUI framework. The View is responsible for defining the structure, layout, and appearance of what users see on the screen.

- **ViewModel**: Logic to manage user interactions and data flow. The ViewModel in MVVM architecture serves as a bridge between the Model and the View. It's responsible for handling the logic for the UI and acts as an abstraction of the View, which contains a View's state and behavior.






---
title: Intro
weight: 0
---

# API's Documentation

This section provides a detailed overview of the related classes for an iOS app, covering API structure, endpoints, request methods, parameters, and expected responses. It includes information on accessing, updating, and retrieving data from AWS and Firebase Firestore databases, as well as authentication and error handling. For additional details or updates, refer to the AWS and Firebase Firestore documentation.

## API Structure

### Base URLs

- **AWS API Gateway**: `https://api.cheer-supports.com/v1`
- **Firebase Firestore**: `https://fcm.googleapis.com/v1/projects/cheer-supports-iphone/messages/`
- **GoogleAPI**: `https://www.googleapis.com/auth/firebase.messaging`

### AWS

- **Authentication Method**: AWS IAM roles and policies.
- **Tokens**: Use AWS Cognito for obtaining JWT tokens.
- **Headers**: Include the `Authorization` header with the `Bearer` token.

### Firebase

- **Authentication Method**: Firebase Authentication (email/password, OAuth providers).
- **Tokens**: Use Firebase ID tokens for authorization.
- **Headers**: Include the `Authorization` header with `Bearer [ID_TOKEN]`.

### Google

- **Authentication Method**: Google Authentication (data, scopes).
- **Tokens**: Use Google API service account.



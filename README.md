## 🔰 با سلام برای ساخت ربات اول باید به وبسایت [ایتار یار](https://eitaayar.ir/) مراجعه کنید 🔰

![UserStep](https://img.shields.io/nuget/v/EitaaGram)
![Nuget](https://img.shields.io/nuget/dt/eitaagram)
---

1.  **یک پروژه ایجاد کنید**
2.  **سپس کتابخانه را نصب کنید و استفاده کنید**

## **⚙️ چگونگی نصب کتابخانه  ⚙️**

```
dotnet add package EitaaGram --version 1.0.0
```

## 🔆 ساخت کلاینت 🔆

```cs
EitaaGramBotClient bot = new EitaaGramBotClient("Your Token");
```

## ✅ دریافت اطلاعات اکانت ✅

```cs
var info = await bot.GetMeAsync();
```

## 📨 ارسال پیام 📨

```cs
var sendedmessageInfo = await bot.SendMessageAsync("chat_id","messsage");
```

## 🔖 ارسال فایل 🔖

```cs
var sendedFileInfo = await bot.SendFileAsync("chat_id","filePath","caption");
```



### **🎁 تمامی امکانات قابل استفاده در ربات های ایتا پیاده سازی شده است اگر ایتا اپدیتی دهد حتما اضافه خواهد شد ، باتشکر  🎁**

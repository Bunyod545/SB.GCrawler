import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DatabaseSettingsComponent } from './layouts/database-settings/database-settings.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzAlertModule } from 'ng-zorro-antd/alert';
import { HomeComponent } from './layouts/home/home.component';
import { JwtInterceptor } from './common/helpers/jwt-interceptor';
import { HomeHeaderComponent } from './layouts/home/components/home-header/home-header.component';
import { HomeSidebarComponent } from './layouts/home/components/home-sidebar/home-sidebar.component';
import { HomeContentComponent } from './layouts/home/components/home-content/home-content.component';
import { InitUserComponent } from './layouts/account/init-user/init-user.component';
import { LoginComponent } from './layouts/account/login/login.component';

registerLocaleData(en);

/**
 * 
 */
@NgModule({
  declarations: [
    AppComponent,
    DatabaseSettingsComponent,
    LoginComponent,
    InitUserComponent,
    HomeComponent,
    HomeHeaderComponent,
    HomeSidebarComponent,
    HomeContentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NzDividerModule,
    NzSelectModule,
    NzInputModule,
    NzButtonModule,
    NzIconModule,
    NzAlertModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent]
})
export class AppModule { }

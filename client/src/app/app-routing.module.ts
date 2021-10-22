import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InitUserComponent } from './layouts/account/init-user/init-user.component';
import { LoginComponent } from './layouts/account/login/login.component';
import { DatabaseSettingsComponent } from './layouts/database-settings/database-settings.component';
import { HomeComponent } from './layouts/home/home.component';

/**
 * 
 */
const routes: Routes = [
  { path: '', component: DatabaseSettingsComponent },
  { path: 'initUser', component: InitUserComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent}
];

/**
 * 
 */
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

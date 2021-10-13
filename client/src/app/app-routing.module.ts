import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatabaseSettingsComponent } from './layouts/database-settings/database-settings.component';
import { LoginComponent } from './layouts/account/pages/login/login.component';
import { InitUserComponent } from './layouts/init-user/init-user.component';
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

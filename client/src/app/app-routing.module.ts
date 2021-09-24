import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatabaseSettingsComponent } from './layouts/database-settings/database-settings.component';
import { LoginComponent } from './layouts/account/pages/login/login.component';
import { CreateAccountComponent } from './layouts/account/pages/create-account/create-account.component';

/**
 * 
 */
const routes: Routes = [
  { path: '', component: DatabaseSettingsComponent },
  { path: 'create-account', component: CreateAccountComponent },
  { path: 'login', component: LoginComponent }
];

/**
 * 
 */
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

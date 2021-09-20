import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatabaseSettingsComponent } from './layouts/database-settings/database-settings.component';

/**
 * 
 */
const routes: Routes = [
  { path: '', component: DatabaseSettingsComponent }
];

/**
 * 
 */
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

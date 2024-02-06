import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';

import {
  AvatarModule,
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
  NavModule,
  ProgressModule,
  TableModule,
  TabsModule
} from '@coreui/angular';

import { WidgetsModule } from '../widgets/widgets.module';
import { ChartjsModule } from '@coreui/angular-chartjs';
import { IconModule } from '@coreui/icons-angular';

@NgModule({
  imports: [
    DashboardRoutingModule,
    WidgetsModule,
    CardModule,
    GridModule,
    NavModule,
    ButtonGroupModule,
    FormModule,
    ReactiveFormsModule,
    ProgressModule,
    ChartjsModule,
    CommonModule,
    TableModule,
    AvatarModule,
    ButtonModule,
    TabsModule,
    IconModule
  ],
  declarations: [DashboardComponent]
})
export class DashboardModule {
}

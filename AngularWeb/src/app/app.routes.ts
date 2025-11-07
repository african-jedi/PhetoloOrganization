import { Routes } from '@angular/router';
import { ComponentHome } from './component-home/component-home';
import { ComponentPass } from './component-pass/component-pass';
import { ComponentFail } from './component-fail/component-fail';

export const routes: Routes = [
    {
        path: '',
        component: ComponentHome
    },
    {
        path: 'pass/:total',
        component: ComponentPass
    },
    {
        path: 'fail/:total',
        component: ComponentFail
    }
];

import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import('./component-home/component-home').then(c => c.ComponentHome)
    },
    {
        path: 'pass/:total',
        loadComponent: () => import('./component-pass/component-pass').then(c => c.ComponentPass)
    },
    {
        path: 'fail/:total',
        loadComponent: () => import('./component-fail/component-fail').then(c => c.ComponentFail)
    },
    {
        path: 'new',
        loadComponent: () => import('./component-new-puzzle/component-new-puzzle').then(c => c.ComponentNewPuzzle)
    },
    {
        path: 'error',
        loadComponent: () => import('./component-error/component-error').then(c => c.ComponentError)
    },
    {
        path: 'test',
        loadComponent: () => import('./component-signal-r/component-signal-r').then(c => c.ComponentSignalR)
    }
];

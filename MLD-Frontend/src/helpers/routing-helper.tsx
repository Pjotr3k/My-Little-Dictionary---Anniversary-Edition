import { Route, RouteProps } from "react-router";

export function mapRoutes(routes: RouteProps[]) {
    return routes.map(route => <Route key={route.path} {...route}/>)
  }
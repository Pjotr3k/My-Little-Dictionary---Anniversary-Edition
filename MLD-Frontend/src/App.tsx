import { Route, RouteProps, RouterProvider, createBrowserRouter, createRoutesFromElements } from "react-router-dom";
import { Suspense, lazy } from "react";
import AppContainer from "./components/app-container/AppContainer";
import Loader from "./components/Loader";
import LoginContainer from "./pages/authentication/LoginContainer";
import Logout from "./pages/authentication/Logout";

const Home = lazy(() => import("./pages/Home"));
const Linguistics  = lazy(() => import("./pages/linguistics/Linguistics"));
const LanguageBrowse  = lazy(() => import("./pages/linguistics/LanguageBrowse"));
const Login  = lazy(() => import("./pages/authentication/Login"));
const SignIn  = lazy(() => import("./pages/authentication/SignIn"));


const authenticationRoutes: RouteProps[] = [
  {
    element: <Suspense fallback={<Loader />}><Login /></Suspense>,
    path: "/login"
  },
  {
    element: <Suspense fallback={<Loader />}><SignIn /></Suspense>,
    path: "/signin"
  },
  {
    element: <Suspense fallback={<Loader />}><Logout /></Suspense>,
    path: "/logout"
  },

]

const routeList: RouteProps[] = [
  {
    index: true,
    element: <Suspense fallback={<Loader />}><Home /></Suspense>
  },
  {
    element: <Suspense fallback={<Loader />}><Linguistics /></Suspense>,
    path: "/linguistics"
  },
  {
    element:  <Suspense fallback={<Loader />}><LanguageBrowse /></Suspense>,
    path: "/linguistics/:id"
  },
]

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route path="/auth" element={<LoginContainer />}>
      {mapRoutes(authenticationRoutes, "/auth")}
        </Route>

    <Route path="/" element={<AppContainer />}>
      {mapRoutes(routeList)}
    </Route>
    </>
  )
)
function App() {
  return <><RouterProvider router={router} /></>
}


function mapRoutes(routes: RouteProps[], prefix: string = "") {
  return routes.map(route =>
    { 

      const path = prefix + route.path
  return <Route key={path} {...route} path={path}/>
})
}

export default App;
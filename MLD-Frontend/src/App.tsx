import { Route, RouteProps, RouterProvider, createBrowserRouter, createRoutesFromElements } from "react-router-dom";
import { Suspense, lazy } from "react";
import AppContainer from "./components/app-container/AppContainer";
import Loader from "./components/Loader";
// import Linguistics from "./pages/linguistics/Linguistics";
// import LanguageBrowse from "./pages/linguistics/LanguageBrowse";

const Home = lazy(() => import("./pages/Home"));
const Linguistics  = lazy(() => import("./pages/linguistics/Linguistics"));
const LanguageBrowse  = lazy(() => import("./pages/linguistics/LanguageBrowse"));


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
    <Route path="/" element={<AppContainer />}>
      {routeList.map(route =>
          <Route key={route.path} {...route} />
        )}
    </Route>
  )
)

function App() {
  return <>
<RouterProvider router={router} />
  </>;
}

export default App;
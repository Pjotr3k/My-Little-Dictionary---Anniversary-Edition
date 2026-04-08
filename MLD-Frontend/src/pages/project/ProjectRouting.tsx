import { Route, RouteProps, Routes } from "react-router";
import { mapRoutes } from "../../helpers/routing-helper";
import { lazy, Suspense } from "react";
import Loader from "../../components/Loader";
import ProjectContainer from "./ProjectContainer";

const Project = lazy(() => import("./Project"));
const Lexicology = lazy(() => import("./lexicology/Lexicology"));
const PartOfSpeech = lazy(() => import("./lexicology/part-of-speech/PartOfSpeech"));
const Dictionary = lazy(() => import("./dictionary/Dictionary"));
const Lexeme = lazy(() => import("./dictionary/Lexeme"));
const Library = lazy(() => import("./library/Library"));
const TextEntry = lazy(() => import("./library/TextEntry"));

const projectRoutes: RouteProps[] = [
    {
      element: <Suspense fallback={<Loader />}><Project /></Suspense>,
      path: ""
    },
    {
      element: <Suspense fallback={<Loader />}><Lexicology /></Suspense>,
      path: "lexicology"
    },
    {
      element:  <Suspense fallback={<Loader />}><PartOfSpeech /></Suspense>,
      path: "lexicology/:pos"
    },
    {
      element: <Suspense fallback={<Loader />}><Dictionary /></Suspense>,
      path: "dictionary"
    },
    {
      element:  <Suspense fallback={<Loader />}><Lexeme /></Suspense>,
      path: "dictionary/:lexeme"
    },
    {
      element: <Suspense fallback={<Loader />}><Library /></Suspense>,
      path: "library"
    },
    {
      element:  <Suspense fallback={<Loader />}><TextEntry /></Suspense>,
      path: "library/:text"
    },
  ]  

export default function ProjectRouting(){
  return (
  <Routes>
    <Route path="/:project" element={<ProjectContainer />}>
    {mapRoutes(projectRoutes)}
    </Route>
  </Routes>)
}
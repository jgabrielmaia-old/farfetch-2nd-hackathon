import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { HomeScreen } from './Home';
import { ClassificationScreen } from './Classification';
import TagsScreen from './Classification/TagsScreen'

const { Navigator, Screen } = createStackNavigator();

const HomeNavigator = () => (
  <Navigator headerMode='none'>
    <Screen name='Home' component={HomeScreen}/>
    <Screen name='NewGame' component={ClassificationScreen}/>
    <Screen name='Tags' component={TagsScreen}/>
  </Navigator>
);

export const AppNavigator = () => (
  <NavigationContainer>
    <HomeNavigator/>
  </NavigationContainer>
);
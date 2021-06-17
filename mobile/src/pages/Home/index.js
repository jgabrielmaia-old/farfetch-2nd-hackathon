import React from 'react';
import { SafeAreaView } from 'react-native';
import { Button, Divider, Layout, TopNavigation } from '@ui-kitten/components';

export const HomeScreen = ({ navigation }) => {

  const navigateNewGame = () => {
    navigation.navigate('NewGame');
  };

  return (
    <SafeAreaView style={{ flex: 1 }}>
      <TopNavigation title='Lookie looks' alignment='center'/>
      <Divider/>
      <Layout style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Button onPress={navigateNewGame}>New Game</Button>
      </Layout>
    </SafeAreaView>
  );
};